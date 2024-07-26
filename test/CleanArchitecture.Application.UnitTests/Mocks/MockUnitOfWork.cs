using CleanArchitecture.Infrastucture.Persistence;
using CleanArchitecture.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    //Objetivo → Representar/Administarr las instancias de los repositorios (Directors,Videos,Streamer)
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{dbContextId}"
                ).Options;

            var streamerDbContextFake = new StreamerDbContext(options);

            streamerDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(streamerDbContextFake);

            return mockUnitOfWork;
        }
    }
}