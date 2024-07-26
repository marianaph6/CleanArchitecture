using MediatR;

namespace CleanArchitecture.Application.Feature.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommand : IRequest
    {
        public int Id { get; set; }
    }
}