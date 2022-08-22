namespace AspNetCoreTemplate.Web.ViewModels.Search
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Web.ViewModels.Minor;

    public class ListViewModel
    {
        public IEnumerable<MinorViewModel> Minors { get; set; }
    }
}
