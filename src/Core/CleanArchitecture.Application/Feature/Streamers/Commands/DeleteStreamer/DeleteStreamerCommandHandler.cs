﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Feature.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStreamerCommandHandler> _logger;

        public DeleteStreamerCommandHandler(
            //IStreamerRepository streamerRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper, ILogger<DeleteStreamerCommandHandler> logger)
        {
            //_streamerRepository = streamerRepository;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            //var streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);
            var streamerToDelete = await _unitOfWork.StreamerRepository.GetByIdAsync(request.Id);

            if (streamerToDelete == null)
            {
                _logger.LogError($"{request.Id} streamer no existe en el sistema");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            //await _streamerRepository.DeleteAsync(streamerToDelete);
            _unitOfWork.StreamerRepository.DeleteEntity(streamerToDelete);
            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.Id} streamer fué eliminado con exito del sistema");

            return Unit.Value;
        }
    }
}