namespace Hospital.Server.Services.Contracts
{
    using Models.AdminViewModels;
    using System.Collections.Generic;

    public interface IAdminService
    {
        List<ResultViewModel> GetAllResults();

        List<PatientViewModel> GetPatients();
    }
}