namespace Hospital.Server.Services
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Repository;
    using Models;
    using System.Linq;

    public class SpecialitiesService : ISpecialitiesService
    {
        private IUnitOfWork Data;

        public SpecialitiesService(IUnitOfWork Data)
        {
            this.Data = Data;
        }

        public SpecialitiesViewModel GetById(int id)
        {

            var currentSpeciality = this.Data
               .Specialities
               .All()
               .Where(s => s.Id == id)
               .Project()
               .To<SpecialitiesViewModel>()
               .FirstOrDefault();

            return currentSpeciality;
        }
    }
}