﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Feature.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStreamerCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStreamerCommandHandler(
            //IStreamerRepository streamerRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper, ILogger<UpdateStreamerCommandHandler> logger)
        {
            //_streamerRepository = streamerRepository;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;   
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            //var streamerToUpdate = await _streamerRepository.GetByIdAsync(request.Id);
            var streamerToUpdate = await _unitOfWork.StreamerRepository.GetByIdAsync(request.Id);

            if (streamerToUpdate == null)
            {
                _logger.LogError($"No se encontró el Streamer id: {request.Id}");
                throw new NotFoundException(nameof(Streamer),request.Id);
            }

            _mapper.Map(request,streamerToUpdate, typeof(UpdateStreamerCommand),typeof(Streamer));

            //await _streamerRepository.UpdateAsync(streamerToUpdate);
            _unitOfWork.StreamerRepository.UpdateEntity(streamerToUpdate);
            await _unitOfWork.Complete();

            _logger.LogInformation($"La operación fué exitosa actualizando el streamer {request.Id}");

            return Unit.Value;
        }
    }
}
