namespace Hospital.Server.Services
{
    using AutoMapper.QueryableExtensions;
    using Data.Repository;
    using Models;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class TrialService : ITrialService
    {
        private IUnitOfWork Data;

        public TrialService(IUnitOfWork data)
        {
            this.Data = data;
        }

        public List<TrialViewModel> GetTrials()
        {
            var allTrials = this.Data
                .ClinicalTrials
                .All()
                .OrderBy(x => x.Price)
                .Project()
                .To<TrialViewModel>()
                .ToList();

            return allTrials;
        }

        public TrialViewModel GetTrialByID(int id)
        {
            var currentSpeciality = this.Data
                .ClinicalTrials
                .All()
                .Where(s => s.Id == id)
                .Project()
                .To<TrialViewModel>()
                .FirstOrDefault();

            return currentSpeciality;
        }
    }
}