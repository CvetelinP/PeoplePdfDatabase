namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Linq;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Minor;
    using AspNetCoreTemplate.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : Controller
    {
        private readonly IMinorServicecs minorService;
        private readonly IDeletableEntityRepository<Minor> minorRepositoty;

        public SearchController(IMinorServicecs minorService, IDeletableEntityRepository<Minor> minorRepositoty)
        {
            this.minorService = minorService;
            this.minorRepositoty = minorRepositoty;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult GetBySearch(string search)
        {
            var viewModle = new ListViewModel();
            var miniors = this.minorService.GetAllByName<MinorViewModel>(search);

            viewModle.Minors = miniors;

            return this.View("Listing", viewModle);
        }

        [HttpGet]
        public IActionResult GetByDate(string year)
        {

            var viewModel = new ListViewModelbyDate();
            var minors = this.minorService.GetDate(year);

            viewModel.Minors = minors;

            return this.View("ListingByDate", viewModel);
        }

    }
}
