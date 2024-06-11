using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastucture.Repository
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {

        public VideoRepository(StreamerDbContext context): base(context)
        {
            
        }
        public async Task<Video> GetVideoByNombre(string nombreVideo)
        {
            var video = await _context.Videos!.Where(v => v.Nombre == nombreVideo).SingleOrDefaultAsync();
            return video!;
        }

        public async Task<IEnumerable<Video>> GetVideoByUserName(string username)
        {
            var listVideos = await _context.Videos!.Where(v => v.CreatedBy == username).ToListAsync();
            return listVideos;
        }
    }
}
