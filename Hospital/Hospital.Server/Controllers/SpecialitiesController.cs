namespace Hospital.Server.Controllers
{
    using Data.Repository;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models;

    public class SpecialitiesController : BaseController
    {
        public SpecialitiesController(IUnitOfWork data): base(data)
        {
        }

        public ActionResult GetSpecialityById(int id)
        {
            var currentSpeciality = this.Data
                .Specialities
                .All()
                .Where(s => s.Id == id)
                .Project()
                .To<SpecialitiesViewModel>()
                .FirstOrDefault();
            
            return View(currentSpeciality);
        }
    }
}