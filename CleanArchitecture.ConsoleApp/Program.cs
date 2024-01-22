using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext dbContext = new();

Streamer streamer = new()
{
    Nombre= "Amazon Prime",
    Url = "https://www.amazonprime.com"
};

dbContext!.Streamers!.Add(streamer);
await dbContext.SaveChangesAsync();

List<Video> movies = new List<Video>()
{
    new Video()
    {
        Nombre = "Mad Max",
        StreamerId = streamer.Id,

    },
    new Video()
    {
        Nombre = "Batman",
        StreamerId = streamer.Id,
    },
    new Video()
    {
        Nombre= "SuperMan",
        StreamerId = streamer.Id,
    }
};

await dbContext.AddRangeAsync(movies);

await dbContext.SaveChangesAsync();