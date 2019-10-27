using GalleryAppAzure.Data;
using GalleryAppAzure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return GetAll().Where(img => img.Id == id).First();
        }

        public IEnumerable<GalleryImage> GetByTag(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }

        public CloudBlobContainer GetBlobConteiner(string azureConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(containerName);
        }

        public async Task SetImage(string title, string tags, Uri uri)
        {
            var image = new GalleryImage
            {
                Title = title,
                Tags = ParseTags(tags),
                Url = uri.AbsoluteUri,
                Created = DateTime.Now
            };

            _galleryAppAzureDbContext.Add(image);
            await _galleryAppAzureDbContext.SaveChangesAsync();
        }

        private IEnumerable<Tag> ParseTags(string tags)
        {
            var tagList = tags.Split(",").ToList();

            var imageList = new List<Tag>();

            foreach (var tag in tagList)
            {
                imageList.Add(new Tag { Description = tag });
            }

            return imageList;
        }
    }
}
