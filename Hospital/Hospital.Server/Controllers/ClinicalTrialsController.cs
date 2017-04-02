namespace Hospital.Server.Controllers
{
    using System.Web.Mvc;
    using Data.Repository;
    using Services.Contracts;

    public class ClinicalTrialsController : BaseController
    {
        private ITrialService trialService;

        public ClinicalTrialsController(IUnitOfWork data, ITrialService trialService) : base(data)
        {
            this.trialService = trialService;
        }

        public ActionResult AllTrials()
        {
            return View(trialService.GetTrials());
        }

        public ActionResult GetClinicalTrialById(int id)
        {
            return View(trialService.GetTrialByID(id));
        }
    }
}