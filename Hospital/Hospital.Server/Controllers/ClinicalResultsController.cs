namespace Hospital.Server.Controllers
{
    using Data.Repository;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models;

    public class ClinicalResultsController : BaseController
    {

        public ClinicalResultsController(IUnitOfWork data): base(data)
        {
        }

        [Authorize]
        public ActionResult GetClinicalResult()
        {
            var result = Data.ClinicalResults
                .All()
                .Where(x => x.Patient.Id == this.UserProfile.Id)
                .OrderByDescending(x => x.AddedOn)
                .Project()
                .To<PatientResultViewModel>()
                .ToList();

            return View(result);
        }
    }
}