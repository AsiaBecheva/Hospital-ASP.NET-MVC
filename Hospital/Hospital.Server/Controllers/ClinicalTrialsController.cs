namespace Hospital.Server.Controllers
{
    using System.Web.Mvc;
    using Data.Repository;
    using System.Linq;
    using Models;
    using AutoMapper.QueryableExtensions;

    public class ClinicalTrialsController : BaseController
    {
        public ClinicalTrialsController(IUnitOfWork data) : base(data)
        {
        }

        public ActionResult AllTrials()
        {
            var allTrial = this.Data
                .ClinicalTrials
                .All()
                .OrderBy(x => x.Price)
                .Project()
                .To<TrialViewModel>()
                .ToList();

            return View(allTrial);
        }

        public ActionResult GetClinicalTrialById(int id)
        {
            var currentSpeciality = this.Data
                .ClinicalTrials
                .All()
                .Where(s => s.Id == id)
                .Project()
                .To<TrialViewModel>()
                .FirstOrDefault();

            return View(currentSpeciality);
        }
    }
}