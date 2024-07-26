using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    /// <summary>
    /// Director Class
    /// </summary>
    public class Director : BaseDomainModel
    {
        /// <summary>
        /// Nombre
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Apellido
        /// </summary>
        public string? Apellido { get; set; }

        /// <summary>
        /// VideoId --> Referencia hacia la clase Video
        /// </summary>
        public int VideoId { get; set; }

        /// <summary>
        /// Video --> Definición de relación de uno a uno entre Director y Video
        /// </summary>
        public virtual Video? Video { get; set; }
    }
}