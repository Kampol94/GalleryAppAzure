using GalleryAppAzure.Data.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GalleryAppAzure.Data
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();
        IEnumerable<GalleryImage> GetByTag(string tag);
        GalleryImage GetById(int id);
        CloudBlobContainer GetBlobConteiner(string azureConnectionString, string containerName);
        Task SetImage(string title, string tags, Uri uri);


    }
}
