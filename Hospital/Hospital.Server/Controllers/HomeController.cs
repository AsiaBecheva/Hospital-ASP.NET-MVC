namespace Hospital.Server.Controllers
{
    using Data.Repository;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models;
    using Services.Contracts;

    public class HomeController : BaseController
    {
        IHomeService homeService;

        public HomeController(IUnitOfWork data, IHomeService homeService) : base(data)
        {
            this.homeService = homeService;
        }

        public ActionResult Index()
        {
            return View(this.homeService.GetSpecialities());
        }
    }
}