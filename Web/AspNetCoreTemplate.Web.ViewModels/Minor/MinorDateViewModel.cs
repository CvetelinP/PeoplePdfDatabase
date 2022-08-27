namespace AspNetCoreTemplate.Web.ViewModels.Minor
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class MinorDateViewModel
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        public string Year { get; set; }
        public string Month { get; set; }

        public string Day { get; set; }

        [Required]

        [Display(Name = "Date of Birthday")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Upload your Presentation in pdf format")]
        [Required]
        public IFormFile FilePdf { get; set; }

        public string FilePdfUrl { get; set; }
    }
}
