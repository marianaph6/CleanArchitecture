using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    /// <summary>
    /// Intrefaz que toma valores genericos (donde la implementación de la clase debe de ser tipo BaseDomainModel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRepository<T> where T:  BaseDomainModel
    {
        /// <summary>
        /// GetAllAsync --> Método generico para obtener todos los objetos T (video, actor, etc)
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAllAsync();


        /// <summary>
        /// GetAsync --> Retorna una colección de datos con determinada condición logica (Expression Func)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T,bool>> predicate);
    }
}
