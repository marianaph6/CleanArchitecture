﻿using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastucture.Persistence;
using CleanArchitecture.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockVideoRepository
    {
        public static Mock<VideoRepository> GetVideoRepository()
        {
            // Crear data de prueba con la libreria Fixture
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var videos = fixture.CreateMany<Video>().ToList();
            videos.Add(fixture.Build<Video>()
                .With(tr => tr.CreatedBy, "System")
                .Create()
                );

            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid}"
                ).Options;

            var streamerDbContextFake = new StreamerDbContext(options);
            streamerDbContextFake.Videos!.AddRange(videos);
            streamerDbContextFake.SaveChanges();

            var mockRepository = new Mock<VideoRepository>(streamerDbContextFake);
            return mockRepository;
        }
    }

}
