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
        public AdministrationController(IUnitOfWork data): base(data)
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
                var ClinResult = new AddResultViewModel()
                {
                    StatusResult = result.StatusResult,
                };

                using (var memory = new MemoryStream())
                {

                }
            }



            return View();
        }
    }
}