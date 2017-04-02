namespace Hospital.Server.Services.Contracts
{
    using Models;
    using System.Collections.Generic;

    public interface IHomeService
    {
        List<SpecialitiesIndexViewModel> GetSpecialities();
    }
}