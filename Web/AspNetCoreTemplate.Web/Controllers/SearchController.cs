namespace AspNetCoreTemplate.Web.Controllers
{
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Minor;
    using AspNetCoreTemplate.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : Controller
    {
        private readonly IMinorServicecs minorService;

        public SearchController(IMinorServicecs minorService)
        {
            this.minorService = minorService;
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
    }
}
