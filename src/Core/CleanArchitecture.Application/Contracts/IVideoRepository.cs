﻿

using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts
{
    public interface IVideoRepository: IAsyncRepository<Video>
    {
        Task<Video> GetVideoByNombre(string nombreVideo);

        Task<IEnumerable<Video>> GetVideoByUserName(string username);
    }
}
