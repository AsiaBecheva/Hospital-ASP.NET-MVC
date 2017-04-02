namespace Hospital.Server.Services
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Repository;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeService : IHomeService
    {
        private IUnitOfWork Data;

        public HomeService(IUnitOfWork data)
        {
            this.Data = data;
        }

        public List<SpecialitiesIndexViewModel> GetSpecialities()
        {
            var allSpecialities = this.Data
                .Specialities
                .All()
                .Project()
                .To<SpecialitiesIndexViewModel>()
                .ToList();

            return allSpecialities;
        }
    }
}