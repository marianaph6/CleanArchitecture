using MediatR;

namespace CleanArchitecture.Application.Feature.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<List<VideosVM>>
    {
        public string _userName { get; set; } = String.Empty;

        public GetVideosListQuery(string username)
        {
            _userName = username ?? throw new ArgumentException(nameof(username)); 
        }
    }
}
