using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XrnCourse.MvvmBasics.Domain.Models;

namespace XrnCourse.MvvmBasics.Domain.Services
{
    public class JsonClassmateRepository : IClassmateRepository
    {
        private readonly string _filePath;

        public JsonClassmateRepository()
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "classmates.json");
        }

        public bool DatastoreExists => File.Exists(_filePath);

        public async Task<IQueryable<Classmate>> GetAll()
        {
            try
            {
                string classmatesJson = File.ReadAllText(_filePath);
                var classmates = JsonConvert.DeserializeObject<IEnumerable<Classmate>>(classmatesJson);
                var classmatesQuery = classmates.AsQueryable();
                return await Task.FromResult(classmatesQuery);
            }
            catch  //return empty collection on file not found, deserialization error, ...
            {
                return (new List<Classmate>()).AsQueryable();
            }
        }

        public async Task<Classmate> GetClassmate(Guid id)
        {
            var sites = await GetAll();
            return sites.FirstOrDefault(e => e.Id == id);
        }

        public async Task<Classmate> UpdateClassmate(Classmate classmate)
        {
            await DeleteClassmate(classmate.Id);
            return await AddClassmate(classmate);
        }

        public async Task<Classmate> AddClassmate(Classmate classmate)
        {
            var classmates = (await GetAll()).ToList();
            classmates.Add(classmate);
            SaveClassmatesToFile(classmates);
            return await GetClassmate(classmate.Id);
        }

        public async Task<Classmate> DeleteClassmate(Guid id)
        {
            var classmates = (await GetAll()).ToList();
            var siteToRemove = classmates.FirstOrDefault(e => e.Id == id);
            classmates.Remove(siteToRemove);
            SaveClassmatesToFile(classmates);
            return siteToRemove;
        }

        protected void SaveClassmatesToFile(IEnumerable<Classmate> mates)
        {
            string sitesJson = JsonConvert.SerializeObject(mates);
            File.WriteAllText(_filePath, sitesJson);
        }
    }
}
