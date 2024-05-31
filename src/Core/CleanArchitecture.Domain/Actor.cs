
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    /// <summary>
    /// Actor Class
    /// </summary>
    public class Actor: BaseDomainModel
    {
        /// <summary>
        /// Se inicializa la coleccion de videos dentro de Actor
        /// </summary>
        public Actor() 
        {
            Videos = new HashSet<Video>();
        }
        /// <summary>
        /// Nombre
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Apellido
        /// </summary>
        public string? Apellido { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}
