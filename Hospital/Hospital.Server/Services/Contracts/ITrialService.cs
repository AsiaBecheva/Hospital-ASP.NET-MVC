namespace Hospital.Server.Services.Contracts
{
    using Models;
    using System.Collections.Generic;

    public interface ITrialService
    {
        List<TrialViewModel> GetTrials();

        TrialViewModel GetTrialByID(int id);
    }
}