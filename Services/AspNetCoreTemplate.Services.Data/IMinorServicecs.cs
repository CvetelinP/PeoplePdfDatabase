namespace AspNetCoreTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Web.ViewModels.Minor;

    public interface IMinorServicecs
    {
        Task CreateAsync(MinorViewModel model);

        IEnumerable<T> GetAll<T>();

        Task UpdateAsync(int id, EditMinorViewModel input);

        T GetById<T>(int id);

        Task<bool> DeleteAsync(int minorId);

        public IEnumerable<T> GetAllByName<T>(string name);
    }
}
