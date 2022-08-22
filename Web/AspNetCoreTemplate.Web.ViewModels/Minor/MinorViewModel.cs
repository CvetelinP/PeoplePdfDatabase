namespace AspNetCoreTemplate.Web.ViewModels.Minor
{
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MinorViewModel : IMapFrom<Minor>
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birthday")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Upload your Presentation in pdf format")]
        [Required]
        public IFormFile FilePdf { get; set; }

        public string FilePdfUrl { get; set; }

    }
}
