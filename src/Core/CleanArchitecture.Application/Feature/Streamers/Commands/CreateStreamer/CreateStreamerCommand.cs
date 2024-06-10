using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Feature.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommand : IRequest<int>
    {
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = string.Empty;


    }
}
