using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Feature.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            var streamerResult = await _streamerRepository.AddAsync(streamerEntity);

            _logger.LogInformation($"Streamer {streamerResult.Id} fué creado con exito");

            await SendEmail(streamerResult);

            return streamerResult.Id;
        }

        public async Task SendEmail(Streamer streamer)
        {
            Email email = new()
            {
                To = "mariana1996.mph@gmail.com",
                Body = "La compañia de streamer se creó correctamente",
                Subject = "Mensaje de alerta"
            };

            try
            {
                await _emailService.SendEmail(email);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviando el de email de {streamer.Id} {ex}");
            }


        }
    }
}
