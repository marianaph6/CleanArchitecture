using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    /// <summary>
    /// Streamer Class
    /// </summary>
    public class Streamer: BaseDomainModel
    {

        /// <summary>
        /// Nombre
        /// </summary>
        public string? Nombre { get; set; } //= string.Empty;

        /// <summary>
        /// Url
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Videos
        /// </summary>
        public ICollection<Video>? Videos { get; set; }     
    }
}
