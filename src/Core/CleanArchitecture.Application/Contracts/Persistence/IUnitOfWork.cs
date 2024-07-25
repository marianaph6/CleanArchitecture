using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        //Saber cuando una transacción ha terminado
        Task<int> Complete();

        IStreamerRepository StreamerRepository {  get; }
        IVideoRepository VideoRepository { get; }
    }
}
