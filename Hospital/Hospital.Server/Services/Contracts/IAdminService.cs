namespace Hospital.Server.Services.Contracts
{
    using DatabaseModels;
    using Models.AdminViewModels;
    using System.Collections.Generic;

    public interface IAdminService
    {
        List<ResultViewModel> GetAllResults();

        List<PatientViewModel> GetPatients();

        PDF GetPDF(AddResultViewModel result);

        Image GetImage(AddDoctorViewModel doctor);
    }
}