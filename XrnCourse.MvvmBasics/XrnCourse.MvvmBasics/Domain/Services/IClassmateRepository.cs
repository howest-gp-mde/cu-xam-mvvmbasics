using System;
using System.Linq;
using System.Threading.Tasks;
using XrnCourse.MvvmBasics.Domain.Models;

namespace XrnCourse.MvvmBasics.Domain.Services
{
    public interface IClassmateRepository
    {
        bool DatastoreExists { get; }

        Task<IQueryable<Classmate>> GetAll();

        Task<Classmate> GetClassmate(Guid id);

        Task<Classmate> UpdateClassmate(Classmate classmate);

        Task<Classmate> AddClassmate(Classmate classmate);

        Task<Classmate> DeleteClassmate(Guid id);
    }
}
