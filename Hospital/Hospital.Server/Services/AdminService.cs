namespace Hospital.Server.Services
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Constants;
    using Data.Repository;
    using Models.AdminViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminService: IAdminService
    {
        private IUnitOfWork Data;

        public AdminService(IUnitOfWork data)
        {
            this.Data = data;
        }

        public List<ResultViewModel> GetAllResults()
        {
            var allresults = this.Data
                .ClinicalResults
                .All()
                .OrderByDescending(x => x.AddedOn)
                .Project()
                .To<ResultViewModel>()
                .ToList();

            return allresults;
        }

        public List<PatientViewModel> GetPatients()
        {
            var patients = this.Data
                .Users
                .All()
                .Where(x => !x.UserName.Contains(GlobalConstants.adminUserName))
                .OrderBy(x => x.UserName)
                .Project()
                .To<PatientViewModel>()
                .ToList();

            return patients;
        }
    }
}