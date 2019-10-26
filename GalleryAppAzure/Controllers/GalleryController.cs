using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryAppAzure.Models;
using Microsoft.AspNetCore.Mvc;

namespace GalleryAppAzure.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var model = new GalleryIndexModel()
            {

            };
            return View(model);
        }
    }
}