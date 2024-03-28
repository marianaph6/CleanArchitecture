using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    /// <summary>
    /// Video Class
    /// </summary>
    public class Video: BaseDomainModel
    {
        /// <summary>
        /// Se inicializa la coleccion de actores dentro de Video
        /// </summary>
        public Video()
        {
            Actores = new HashSet<Actor>();
        }
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

        public virtual ICollection<Actor> Actores { get; set; }

        /// <summary>
        /// Director --> Definición de relación de uno a uno entre Director y Video
        /// </summary>
        public virtual Director Director { get; set; }
    }
}
