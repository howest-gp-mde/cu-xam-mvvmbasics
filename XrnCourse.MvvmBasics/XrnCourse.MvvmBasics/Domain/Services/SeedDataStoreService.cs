using System;
using XrnCourse.MvvmBasics.Domain.Models;

namespace XrnCourse.MvvmBasics.Domain.Services
{
    /// <summary>
    /// this implementation of ISeederService will seed the repository
    /// only when the backing datastore does not exist.
    /// </summary>
    public class SeedDataStoreService : ISeederService
    {
        private IClassmateRepository _repository;

        public SeedDataStoreService(IClassmateRepository repository)
        {
            _repository = repository;
        }

        public void EnsureSeeded()
        {
            if (!_repository.DatastoreExists)
            {
                _repository.AddClassmate(
                    new Classmate { Id = Guid.NewGuid(), Name = "Siegfried",
                                    Birthdate = new DateTime(1981, 1, 7), Phone = "+00 111 222 333" });
                _repository.AddClassmate(
                    new Classmate{  Id= Guid.NewGuid(), Name ="Karlina",
                                    Birthdate = new DateTime(1990,8,26), Phone="+00 444 555 666" });
                _repository.AddClassmate(
                    new Classmate{  Id= Guid.NewGuid(), Name ="Isana",
                                    Birthdate = new DateTime(2001,11,2), Phone="+00 777 888 999" });
            }
        }
    }
}
