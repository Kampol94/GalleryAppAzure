using System;
using System.Collections.Generic;
using GalleryAppAzure.Data.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace GalleryAppAzure.Data
{
    public class GalleryAppAzureDbContext : DbContext
    {
        public GalleryAppAzureDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<Tag> Tags { get; set; }


    }
}
