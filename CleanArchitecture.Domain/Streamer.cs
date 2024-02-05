namespace CleanArchitecture.Domain
{
    /// <summary>
    /// Streamer Class
    /// </summary>
    public class Streamer
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

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
        public List<Video>? Videos { get; set; }     
    }
}
