namespace Hospital.Server.Controllers
{
    using Data.Repository;
    using System.Web.Mvc;
    using Services.Contracts;

    public class SpecialitiesController : BaseController
    {
        private ISpecialitiesService specialitiesService;

        public SpecialitiesController(IUnitOfWork data, ISpecialitiesService specialitiesService) : base(data)
        {
            this.specialitiesService = specialitiesService;
        }

        public ActionResult GetSpecialityById(int id)
        {
            return View(specialitiesService.GetById(id));
        }
    }
}