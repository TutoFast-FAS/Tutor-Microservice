using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TutoFast.TutorCatalog.Service.Entities;

namespace TutoFast.TutorCatalog.Service.Repositories
{
    public interface ITutorsRepository
    {
        Task CreateAsync(Tutor entity);
        Task<IReadOnlyCollection<Tutor>> GetAllAsync();
        Task<Tutor> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Tutor entity);
    }
}