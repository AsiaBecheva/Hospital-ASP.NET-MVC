namespace Hospital.Server.Controllers
{
    using System.Web.Mvc;
    using Data.Repository;
    using Services;
    using System.Web;

    public class DoctorsController : BaseController
    {
        private IDoctorService doctorService;

        public DoctorsController(IUnitOfWork data, IDoctorService doctorService) : base(data)
        {
            this.doctorService = doctorService;
        }

        public ActionResult AllDoctors()
        {
            return View(this.doctorService.GetDoctors());
        }

        public ActionResult GetDoctorById(int id)
        {
            var doctor = this.doctorService.GetById(id);

            if (doctor != null)
            {
                return View(doctor);
            }

            return HttpNotFound("There is no doctor with such ID!");
        }

        public ActionResult Image(int id)
        {
            var img = this.Data.Images.GetById(id);

            if (img == null)
            {
                throw new HttpException("Image not found");
            }

            return File(img.Content, "image/jpg");
        }
    }
}