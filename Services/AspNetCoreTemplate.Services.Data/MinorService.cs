namespace AspNetCoreTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.ViewModels.Minor;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    public class MinorService : IMinorServicecs
    {
        private readonly IDeletableEntityRepository<Minor> minorRepository;

        public MinorService(IDeletableEntityRepository<Minor> minorRepository)
        {
            this.minorRepository = minorRepository;
        }

        public async Task CreateAsync(MinorViewModel model)
        {
            Minor minor = new Minor()
            {
                Id = model.Id,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                FilePdfUrl = model.FilePdfUrl,
            };

            await this.minorRepository.AddAsync(minor);
            await this.minorRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int minorId)
        {
            var minor = this.minorRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == minorId);

            if (minor == null)
            {
                return false;
            }

            this.minorRepository.Delete(minor);
            await this.minorRepository.SaveChangesAsync();

            return true;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var query = this.minorRepository.All();


            return query.To<T>().ToList();
        }

        public IEnumerable<T> GetAllByName<T>(string search)
        {
            if (search is null)
            {
               return Enumerable.Empty<T>();
            }

            var minors = this.minorRepository.All().Where(x => x.Name.ToLower().Contains(search.ToLower()));

            return minors.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var minor = this.minorRepository.AllAsNoTracking().Where(x => x.Id == id).To<T>().FirstOrDefault();
            return minor;
        }

        public async Task UpdateAsync(int id, EditMinorViewModel input)
        {
            var minor = this.minorRepository.All().FirstOrDefault(x => x.Id == id);
            minor.Name = input.Name;
            minor.DateOfBirth = input.DateOfBirth;
            minor.FilePdfUrl = input.FilePdfUrl;

            await this.minorRepository.SaveChangesAsync();
        }

    }
}
