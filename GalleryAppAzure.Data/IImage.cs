using GalleryAppAzure.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryAppAzure.Data
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();
        IEnumerable<GalleryImage> GetByTag(string tag);
        GalleryImage GetById(int id);
    }
}
