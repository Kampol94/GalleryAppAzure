using GalleryAppAzure.Data;
using GalleryAppAzure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GalleryAppAzure.Services
{
    public class ImageService : IImage
    {
        GalleryAppAzureDbContext _galleryAppAzureDbContext;

        public ImageService(GalleryAppAzureDbContext galleryAppAzureDbContext)
        {
            _galleryAppAzureDbContext = galleryAppAzureDbContext;
        }

        public IEnumerable<GalleryImage> GetAll()
        {
            return _galleryAppAzureDbContext.GalleryImages.Include( img => img.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return _galleryAppAzureDbContext.GalleryImages.Find(id);
        }

        public IEnumerable<GalleryImage> GetByTag(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }
    }
}
