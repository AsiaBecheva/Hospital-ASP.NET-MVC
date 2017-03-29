namespace Hospital.Server.Controllers
{
    using Data.Constants;
    using Data.Repository;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models.AdminViewModels;

    [Authorize(Roles = GlobalConstants.adminRoleName)]
    public class AdministrationController : BaseController
    {
        public AdministrationController(IUnitOfWork data): base(data)
        {
        }

        public ActionResult Patients()
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
    }
}