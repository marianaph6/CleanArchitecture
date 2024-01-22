﻿using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\sqlexpress;
                                        Initial Catalog=Streamer; Integrated Security=True");
        }
        public DbSet<Streamer>? Streamers { get; set; }

        public DbSet<Video>? Videoa { get; set; }
    }
}
