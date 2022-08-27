namespace AspNetCoreTemplate.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Web.ViewModels.Minor;

    public  class ListViewModelbyDate
    {
        public IList<MinorDateViewModel> Minors { get; set; }
    }
}
