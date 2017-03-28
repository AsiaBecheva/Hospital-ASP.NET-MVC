namespace Hospital.Server.Controllers
{
    using Data.Repository;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models;

    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork data): base(data)
        {
        }

        public ActionResult Index()
        {
            var allSpecialities = this.Data
                .Specialities
                .All()
                .Project()
                .To<SpecialitiesIndexViewModel>()
                .ToList();

            return View(allSpecialities);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}