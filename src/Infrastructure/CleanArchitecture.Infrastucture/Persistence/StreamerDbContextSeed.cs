using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastucture.Persistence
{
    public class StreamerDbContextSeed
    {
        /// <summary>
        /// Añadir datos siempre y cuando la entidad no tenga datos
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {

            if(context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(StreamerDbContextSeed).Name);
            }
        }


        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>()
            {
                new()
                {
                    CreatedBy = "marianamph6",
                    Nombre = "Maxi HBP",
                    Url = "https://es.wikipedia.org/wiki/Sitio_web"

                },
                new()
                {
                    CreatedBy = "marianamph6",
                    Nombre = "Amazon VIP",
                    Url = "https://es.wix.com/blog"

                }
            };
        }
    }
}
