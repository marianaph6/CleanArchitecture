﻿using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();


// await AddNewRecords();

// QueryStreaming();

// await QueryFilter();

// await QueryMethods();

// await QueryLinq();

//await TrackingAndNotTracking();

//await AddNewStreamerWithVideo();

// await AddNewStreamerWithVideoId();

// await AddNewActorWithVideo();

// await AddNewDirectorWithVideo();

await MultipleEntitiesQuery();

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

async Task QueryMethods()
{
    var streamer = dbContext!.Streamers!;

    //El resultado puede ser una lista y luego selecciona el primer valor 
    var streamerFirstAsync = await streamer.Where(x => x.Nombre.Contains("a")).FirstAsync();
    var streamersFirstOrDefaultAsync = streamer.Where(x => x.Nombre.Contains("a")).FirstOrDefaultAsync();
    var streamersFirstOrDefaultAsyncV2 = streamer.FirstOrDefaultAsync(x => x.Nombre.Contains("a"));

    //En la consulta el resultado es solo un valor
    var singleAsync = streamer.Where(x => x.Id == 1).SingleAsync();
    var singleOrDefaultAsync = streamer.Where(x=> x.Id == 2).SingleOrDefaultAsync();

    //Buscar por la primary Key (Id)
    var resultado = streamer.FindAsync(1);
}


async Task QueryLinq()
{
    Console.WriteLine($"Ingrese el servicio de Streaming");
    string streamerNombre = Console.ReadLine();
    // i representa la data de los campos de la columna de la entidad
    var streamers =  await (from i in dbContext.Streamers
                            where EF.Functions.Like(i.Nombre, $"%{streamerNombre}%")
                            select i).ToListAsync();  // --> Retornar todos los records de la tabla streamers

    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} -- {streamer.Nombre}");
    }
}


async Task TrackingAndNotTracking()
{
    var streamerWithTracking = await dbContext!.Streamers!.FirstOrDefaultAsync(x=> x.Id == 4);
    var streamerWithNotTracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 5);

    // No se puede utilizar el NoTracking cuando se utilice el FindAsync()
    // Si se utiliza el no tracking libera el objeto de la memoria temporal por lo cual no se podria utilizar

    streamerWithTracking.Nombre = "Netflix Super";
    streamerWithNotTracking.Nombre = "Amazon Plus";


    dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo() 
{
    // Se hace la insercción (con el objeto Streamer) de un record para una nueva compañia de streaming (pantalla), 
    // la cual tendrá un nuevo video (hunger games)

    var pantalla = new Streamer
    {
        Nombre = "pantalla"
    };

    var hungerGames = new Video
    {
        Nombre = "Hunger Games",
        Streamer = pantalla,
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideoId()
{
    // Se hace la insercción (con el IdStreamer ya existente) de un record para una nueva compañia de streaming (pantalla), 
    // la cual tendrá un nuevo video (hunger games)

    var batmanForever = new Video
    {
        Nombre = "Hunger Games",
        StreamerId = 7,
    };

    await dbContext.AddAsync(batmanForever);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pitt",
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Pietro",
        VideoId = 1
    };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();

}


async Task MultipleEntitiesQuery()
{

    // Retornar videos que tengan el Id = 1. Adicional se queiren incluir todos los actores que pertenezcan al video

    //Trae el video con su lista de actores

    //var videoWithActores = await dbContext!.Videos!.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id ==1);

    //var actor = await dbContext.Actores!.Select(q=> q.Nombre).ToListAsync();

    var videoWithDirector = await dbContext.Videos!
                            .Where(q => q.Director != null) //Traerá solo las peliculas que tengan un director
                            .Include(q => q.Director)
                            .Select(q =>
                                new
                                {
                                    Director_Nombre_Completo = $"{q.Director.Nombre} {q.Director.Apellido}",
                                    Movie = q.Nombre
                                }
                            ).ToListAsync();

    foreach(var pelicula in videoWithDirector)
    {
        Console.WriteLine($"{pelicula.Movie}  -- {pelicula.Director_Nombre_Completo}");
    }


}
