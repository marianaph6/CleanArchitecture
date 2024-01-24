using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();


//await AddNewRecords();
//QueryStreaming();
await QueryFilter();

#if DEBUG
    Console.WriteLine("Press enter to close...");
    Console.ReadLine();
#endif

async Task QueryFilter()
{
    Console.WriteLine($"Ingrese una compañia de Streaming");
    string streamingNombre = Console.ReadLine();

    //Consulta filtrando que el nombre sea igual
    List<Streamer> streamers = await dbContext!.Streamers!.Where(x => x.Nombre.Equals(streamingNombre)).ToListAsync();
    foreach (Streamer streamer in streamers)
    {
        Console.WriteLine($"Resultado QueryFilter Equals {streamer.Id} -- {streamer.Nombre}");
    }

    // Consulta filtrando que el nombre sea parcial

    //var streamerPartialResults = await dbContext.Streamers.Where(x => x.Nombre.Contains(streamingNombre)).ToListAsync();

    var streamerPartialResults = await dbContext.Streamers.Where(x => EF.Functions.Like(x.Nombre, $"%{streamingNombre}%")).ToListAsync();

    foreach (Streamer streamer in streamerPartialResults)
    {
        Console.WriteLine($"Resultado QueryFilter Contains {streamer.Id} -- {streamer.Nombre}");
    }
}

/// Obtener todos los Streamers
void QueryStreaming()
{
    var Stremers = dbContext!.Streamers!.ToList();
    foreach (var streamer in Stremers)
    {
        Console.WriteLine($"{streamer.Id}  - {streamer.Nombre}");
    }
}

// Añadir un nuevo Streammer con sus respecivas peliculas
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