using AutoMapper;
using CleanArchitecture.Application.Feature.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Feature.Videos.Queries.GetVideosList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVM>().ReverseMap();
            CreateMap<CreateStreamerCommand, Streamer>().ReverseMap();
        }
    }
}
