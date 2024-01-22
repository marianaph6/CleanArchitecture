using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext dbContext = new();


//await AddNewRecords();
QueryStreaming();

void QueryStreaming()
{
    var Stremers = dbContext.Streamers.ToList();
    foreach (var streamer in Stremers)
    {
        Console.WriteLine($"{streamer.Id}  - {streamer.Nombre}");
    }
}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "https://www.disney.com"
    };

    dbContext!.Streamers!.Add(streamer);
    await dbContext.SaveChangesAsync();

    List<Video> movies = new List<Video>()
{
    new Video()
    {
        Nombre = "La Sirenita",
        StreamerId = streamer.Id,

    },
    new Video()
    {
        Nombre = "Cenicienta",
        StreamerId = streamer.Id,
    },
    new Video()
    {
        Nombre= "La Bella y la Bestia",
        StreamerId = streamer.Id,
    },
    new Video()
    {
        Nombre= "Star Wards",
        StreamerId = streamer.Id,
    }
};

    await dbContext.AddRangeAsync(movies);

    await dbContext.SaveChangesAsync();
}