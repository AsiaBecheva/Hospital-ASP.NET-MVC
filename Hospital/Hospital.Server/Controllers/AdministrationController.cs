namespace Hospital.Server.Controllers
{
    using Data.Constants;
    using Data.Repository;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models.AdminViewModels;
    using DatabaseModels;
    using System.IO;

    [Authorize(Roles = GlobalConstants.adminRoleName)]
    public class AdministrationController : BaseController
    {
        public AdministrationController(IUnitOfWork data) : base(data)
        {
        }

        public ActionResult ClinicalResults()
        {
            var allresults = this.Data
                .ClinicalResults
                .All()
                .OrderByDescending(x => x.AddedOn)
                .Project()
                .To<ResultViewModel>()
                .ToList();

            return View(allresults);
        }

        public ActionResult Patients()
        {
            var patients = this.Data
                .Users
                .All()
                .Where(x => !x.Email.ToLower().Contains("admin"))
                .OrderByDescending(x => x.UserName)
                .Project()
                .To<PatientViewModel>()
                .ToList();

            return View(patients);
        }

        [HttpGet]
        public ActionResult AddResult(string id)
        {
            var forUser = this.Data.Users
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            var result = new AddResultViewModel()
            {
                Patient = forUser
            };

            return View(result);
        }

        [HttpPost]
        public ActionResult AddResult(AddResultViewModel result)
        {
            if (ModelState.IsValid)
            {
                var patient = this.Data.Users
                    .GetById(result.PatientId);


                var file = new PDF()
                {
                    FileName = result.UploadedFile.FileName,
                };

                using (var memory = new MemoryStream())
                {
                    result.UploadedFile.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();
                    file.Content = content;
                }

                var clinRes = new ClinicalResult()
                {
                    StatusResult = result.StatusResult,
                    File = file,
                };

                patient.ClinicalResults.Add(clinRes);

                this.Data.SaveChanges();

                return RedirectToAction("Patients");
            }
            return View(result);
        }
    }
}