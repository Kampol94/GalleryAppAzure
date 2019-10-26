using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryAppAzure.Data.Models;
using GalleryAppAzure.Models;
using Microsoft.AspNetCore.Mvc;

namespace GalleryAppAzure.Controllers
{
    public class GalleryController : Controller
    {
        


        public IActionResult Index()
        {
            var hinikingImagesTags = new List<Tag>();
            var cityImagesTags = new List<Tag>();

            var tag1 = new Tag()
            {
                Description = "Adventure",
                Id = 0
            };
            var tag2 = new Tag()
            {
                Description = "Urban",
                Id = 1
            };
            var tag3 = new Tag()
            {
                Description = "New York",
                Id = 2
            };

            hinikingImagesTags.Add(tag1);
            cityImagesTags.AddRange(new List<Tag>{ tag2,tag3});

            var imageList = new List<GalleryImage>()
            {
                new GalleryImage()
                {
                    Title = "Hiking Trip",
                    Url = "https://static.westernunion-microsites.com/blog/uploads/2016/12/Hiking-Cover-e1481132901201.jpg",
                    Created = DateTime.Now,
                    Tags = hinikingImagesTags
                },
                 new GalleryImage()
                {
                    Title = "On The Trail",
                    Url = "https://image.freepik.com/free-photo/leaves-rail_426-19314790.jpg",
                    Created = DateTime.Now,
                    Tags = hinikingImagesTags
                },
                  new GalleryImage()
                {
                    Title = "Downtown",
                    Url = "https://28nwgk2wx3p52fe6o9419sg5-wpengine.netdna-ssl.com/wp-content/uploads/2019/07/downtown-jersey-city-entertainment-licenses-ordiance.jpg",
                    Created = DateTime.Now,
                    Tags = cityImagesTags
                }
            };

            var model = new GalleryIndexModel()
            {
                Images = imageList,
                SearchQuery = ""
            };
            return View(model);
        }
    }
}