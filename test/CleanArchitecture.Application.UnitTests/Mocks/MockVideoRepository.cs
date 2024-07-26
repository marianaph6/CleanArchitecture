using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastucture.Persistence;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockVideoRepository
    {
        public static void AddDataVideoRepository(StreamerDbContext streamerDbContextFake)
        {
            // Crear data de prueba con la libreria Fixture
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var videos = fixture.CreateMany<Video>().ToList();
            videos.Add(fixture.Build<Video>()
                .With(tr => tr.CreatedBy, "System")
                .Create()
                );

            streamerDbContextFake.Videos!.AddRange(videos);
            streamerDbContextFake.SaveChanges();
        }
    }
}