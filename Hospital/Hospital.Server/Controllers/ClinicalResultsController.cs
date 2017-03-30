namespace Hospital.Server.Controllers
{
    using Data.Repository;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models;
    using DatabaseModels;

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

        public ActionResult DownloadResult(int id)
        {
            var clinicalResult = this.Data.ClinicalResults.GetById(id);
            if (clinicalResult != null)
            {
                PDF file = clinicalResult.File;

                return File(file.Content, "text/plain", file.FileName);
            }

            return RedirectToAction("GetClinicalResult");
        }
    }
}