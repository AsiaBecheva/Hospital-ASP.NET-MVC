namespace Hospital.Server.Services
{
    using AutoMapper.QueryableExtensions;
    using Data.Repository;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class DoctorService : IDoctorService
    {
        private IUnitOfWork Data;

        public DoctorService(IUnitOfWork data)
        {
            this.Data = data;
        }


        public List<DoctorViewModel> GetDoctors()
        {
            var allDocs = this.Data
                .Doctors
                .All()
                .OrderByDescending(x => x.Name)
                .Project()
                .To<DoctorViewModel>()
                .ToList();

            return allDocs;
        } 

        public DoctorViewModel GetById(int id)
        {
            var doc = this.Data
               .Doctors
               .All()
               .Where(x => x.Id == id)
               .Project()
               .To<DoctorViewModel>()
               .FirstOrDefault();

            return doc;
        }
    }
}