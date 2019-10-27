using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GalleryAppAzure.Data;
using GalleryAppAzure.Models;
using GalleryAppAzure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GalleryAppAzure.Controllers
{
    public class ImageController : Controller
    {
        private IConfiguration _config;
        private IImage _imageService;

        private string AzureConnectionString { get; }

        public ImageController(IConfiguration config, IImage imageService)
        {
            _config = config;
            AzureConnectionString = _config["AzureConnectionString"];
            _imageService = imageService;
        }

        public IActionResult Upload()
        {
            var model = new UploadImageModel();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadNewImage(IFormFile file, string tags, string title)
        {

            var container = _imageService.GetBlobConteiner(AzureConnectionString, "images");

            var content = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var fileName = content.FileName.Trim('"');

            var blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
            await _imageService.SetImage(title, tags, blockBlob.Uri);

            return RedirectToAction("Index", "Gallery");
        }
    }
}