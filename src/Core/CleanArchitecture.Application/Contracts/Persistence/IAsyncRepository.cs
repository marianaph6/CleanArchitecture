using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    /// <summary>
    /// Intrefaz que toma valores genericos (donde la implementación de la clase debe de ser tipo BaseDomainModel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        /// <summary>
        /// GetAllAsync → Método generico para obtener todos los objetos T (video, actor, etc)
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// GetAsync → Retorna una colección de datos con determinada condición logica (Expression Func)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// GetAsync → Incluir el ordenamiento en los resultados
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name=""></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);

        /// <summary>
        /// GetAsync → Hacer relaciones entre entidades a la hora de ejecutar el query
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeString"></param>
        /// <param name="disableTracking"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        List<Expression<Func<T, object>>> includes = null,
                                        bool disableTracking = true);

        /// <summary>
        /// GetByIdAsync → Buscar por el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// AddAsync → Añadir registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// UpdateAsync → Actualizar registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// DeleteAsync → Eliminar registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

        void AddEntity(T entity);

        void UpdateEntity(T entity);

        void DeleteEntity(T entity);
    }
}