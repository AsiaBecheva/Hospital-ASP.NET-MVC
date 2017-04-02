namespace Hospital.Server.Services
{
    using Models;
    using System.Collections.Generic;

    public interface IDoctorService
    {
        List<DoctorViewModel> GetDoctors();

        DoctorViewModel GetById(int id);
    }
}