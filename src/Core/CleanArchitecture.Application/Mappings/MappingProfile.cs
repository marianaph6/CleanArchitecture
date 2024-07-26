using AutoMapper;
using CleanArchitecture.Application.Feature.Directors.Commands.CreateDirector;
using CleanArchitecture.Application.Feature.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Feature.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Feature.Videos.Queries.GetVideosList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>().ReverseMap();
            CreateMap<CreateStreamerCommand, Streamer>().ReverseMap();
            CreateMap<CreateDirectorCommand, Director>().ReverseMap();
            CreateMap<UpdateStreamerCommand, Streamer>().ReverseMap();
        }
    }
}