namespace AspNetCoreTemplate.Data.Models
{
    using System;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Minor : BaseDeletableModel<int>
    {

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FilePdfUrl { get; set; }
    }
}
