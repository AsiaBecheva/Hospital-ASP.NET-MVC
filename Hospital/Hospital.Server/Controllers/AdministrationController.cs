namespace Hospital.Server.Controllers
{
    using System.Web.Mvc;

    public class AdministrationController : Controller
    {
        public ActionResult Index()
        {
            return View(1);
        }
    }
}