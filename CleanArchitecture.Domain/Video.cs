namespace CleanArchitecture.Domain
{
    /// <summary>
    /// Video Class
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// StreamerId
        /// </summary>
        public int StreamerId { get; set; }

        /// <summary>
        /// Streamer
        /// </summary>
        public virtual Streamer? Streamer { get; set; } 
        //virtual --> Indicando que puede ser sobreescrito por una clase derivada en el futuro
    }
}
