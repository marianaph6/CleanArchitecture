
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    /// <summary>
    /// Director Class
    /// </summary>
    public class Director: BaseDomainModel
    {
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido
        /// </summary>
        public string Apellido { get; set; }
    }
}
