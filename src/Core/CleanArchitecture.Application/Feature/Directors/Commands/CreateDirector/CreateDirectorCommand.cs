using MediatR;

namespace CleanArchitecture.Application.Feature.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommand : IRequest<int>
    {
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Apellido
        /// </summary>
        public string Apellido { get; set; } = string.Empty;

        /// <summary>
        /// VideoId --> Referencia hacia la clase Video
        /// </summary>
        public int VideoId { get; set; }
    }
}