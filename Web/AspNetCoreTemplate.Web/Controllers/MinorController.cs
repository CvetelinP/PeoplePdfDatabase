namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Minor;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class MinorController : Controller
    {
        private readonly IMinorServicecs minorServicecs;
        private readonly IWebHostEnvironment webHostEnvironment;


        public MinorController(IMinorServicecs minorServicecs, IWebHostEnvironment webHostEnvironment)
        {
            this.minorServicecs = minorServicecs;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MinorViewModel model)
        {
            if (model.FilePdf != null)
            {
                string folder = "file/pdf/";
                model.FilePdfUrl = await this.UploadImage(folder, model.FilePdf);
            }

            await this.minorServicecs.CreateAsync(model);

            return this.Redirect("Add");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.minorServicecs.DeleteAsync(id);
            if (!isDeleted)
            {
                return this.NotFound();
            }

            return this.Redirect($"/Home/Index?id ={id}");
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(this.webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }

}
