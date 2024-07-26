using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastucture.Persistence;
using System.Collections;

namespace CleanArchitecture.Infrastucture.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly StreamerDbContext _context;

        private IVideoRepository _videoRepository;
        private IStreamerRepository _streamerRepository;

        //Inyección via propiedades
        // ??= --> Que no sea nulo
        public IVideoRepository VideoRepository => _videoRepository ??= new VideoRepository(_context);

        public IStreamerRepository StreamerRepository => _streamerRepository ??= new StreamerRepository(_context);

        public UnitOfWork(StreamerDbContext context)
        {
            _context = context;
        }

        public StreamerDbContext StreamerDbContext => _context;

        //Disparar la confirmación de todas las transacciones que se estan realizando
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        //Se elimina el context cuando la transacción finalice
        public void Dispose()
        {
            _context.Dispose();
        }

        // Instancia del respositorio
        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable(); //Crea la colección
            }
            var type = typeof(TEntity).Name; //Obtener el nombre de la entidad

            if (!_repositories.ContainsKey(type)) //Validar si no existe la entidad para crearla
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}