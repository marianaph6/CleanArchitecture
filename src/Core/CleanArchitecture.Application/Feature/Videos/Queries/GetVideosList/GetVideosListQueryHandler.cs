using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Feature.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVM>>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;     
        }

        /// <summary>
        /// Aquí se incorpora la logica para hacer la consulta a la BD que obtenga la lista de videos por el username
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<VideosVM>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            var videoList =  await _videoRepository.GetVideoByUserName(request._userName);

            return _mapper.Map<List<VideosVM>>(videoList);  
        }
    }
}
