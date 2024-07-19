using CleanArchitecture.Application.Constants;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email) ?? throw new Exception($"El usuario con Email {request.Email} no existe");

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password,false,lockoutOnFailure:false);

            if (!result.Succeeded)
            {
                throw new Exception($"Las credenciales son incorrectas");
            }

            var token = await GenerateToken(user);

            AuthResponse authResponse = new()
            {
                UserName = user.UserName,
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email
            };

            return authResponse;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);

            if(existingUser != null)
            {
                throw new Exception("El username ya fué tomado por otra cuenta");
            }

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if(existingEmail != null)
            {
                throw new Exception("El email ya fué tomado por otra cuenta");
            }

            ApplicationUser user = new()
            {
                Email = request.Email,
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                UserName = request.Username,
                EmailConfirmed = true,

            };

            var result = await _userManager.CreateAsync(user,request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Operator");
                var token = await GenerateToken(user);
                return new RegistrationResponse
                {
                    Email = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserId = user.Id,
                    UserName = user.UserName,
                };
            }

            throw new Exception($"{result.Errors}");
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            // Claim → Data del usuario que será usada para generar el token
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            List<Claim> roleClaims = new();
            
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            //Claim → Diccionario de datos → Key (primer valor), Valor (segundo parametro)

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName), //Almacenar username
                new Claim(JwtRegisteredClaimNames.Email, user.Email), //Almacenar Email
                new Claim(CustomClaimTypes.Uid, user.Id)
                //Si deseo crear un propio claim → Hacer una clase estatica para colocar las constantes (almacenadas en la capa de aplicación)
            }.Union(userClaims).Union(roleClaims);

            // Algoritmo oKey para acceder a la data
            // Se le pasa como parametro la clave o frase de seguridad
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( _jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutues),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }
    }
}
