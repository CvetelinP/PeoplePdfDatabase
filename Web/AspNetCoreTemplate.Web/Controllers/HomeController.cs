namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.ViewModels;
    using AspNetCoreTemplate.Web.ViewModels.Minor;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IMinorServicecs minorServicecs;
        private readonly IDeletableEntityRepository<Minor> minorRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(IMinorServicecs minorServicecs, IDeletableEntityRepository<Minor> minorRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.minorServicecs = minorServicecs;
            this.minorRepository = minorRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var useModel = new MinorListViewModel();

            var model = this.minorRepository.All().To<MinorViewModel>().ToList();

            useModel.Minors = model;

            return this.View(useModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult Edit(int id)
        {
            var minor = this.minorServicecs.GetById<EditMinorViewModel>(id);
            return this.View(minor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditMinorViewModel model)
        {
            if (model.FilePdf != null)
            {
                string folder = "file/pdf/";
                model.FilePdfUrl = await this.UploadImage(folder, model.FilePdf);
            }

            await this.minorServicecs.UpdateAsync(id, model);
            return this.RedirectToAction(nameof(this.Index), new { id });
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
