namespace AspNetCoreTemplate.Web.ViewModels.Minor
{
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class EditMinorViewModel : MinorViewModel, IMapFrom<Minor>
    {
        public int Id { get; set; }
    }
}
