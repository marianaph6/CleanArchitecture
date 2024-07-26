using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Feature.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        //private readonly IVideoRepository _videoRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(
            //IVideoRepository videoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            //_videoRepository = videoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Aquí se incorpora la logica para hacer la consulta a la BD que obtenga la lista de videos por el username
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            //var videoList =  await _videoRepository.GetVideoByUserName(request._userName);

            var videoList = await _unitOfWork.VideoRepository.GetVideoByUserName(request._userName);

            return _mapper.Map<List<VideosVm>>(videoList);
        }
    }
}