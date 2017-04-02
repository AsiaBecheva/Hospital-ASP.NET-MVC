namespace Hospital.Server.Controllers
{
    using Data.Constants;
    using Data.Repository;
    using System.Web.Mvc;
    using Models.AdminViewModels;
    using DatabaseModels;
    using Services.Contracts;
    using Services;
    using System.Linq;
    using AutoMapper;

    [Authorize(Roles = GlobalConstants.adminRoleName)]
    public class AdministrationController : BaseController
    {

        private IAdminService adminService;
        private IDoctorService doctorService;

        public AdministrationController(IUnitOfWork data, IAdminService adminService, IDoctorService doctorService) : base(data)
        {
            this.adminService = adminService;
            this.doctorService = doctorService;
        }


        public ActionResult ClinicalResults()
        {
            return View(this.adminService.GetAllResults());
        }

        public ActionResult Patients()
        {
            return View(this.adminService.GetPatients());
        }

        [HttpGet]
        public ActionResult AddResult(string id)
        {
            var result = new AddResultViewModel()
            {
                Patient = this.Data.Users.GetById(id)
            };

            return View(result);
        }

        [HttpPost]
        public ActionResult AddResult(AddResultViewModel result)
        {
            if (ModelState.IsValid)
            {
                var patient = this.Data.Users.GetById(result.PatientId);

                var clinRes = new ClinicalResult()
                {
                    StatusResult = result.StatusResult,
                    File = this.adminService.GetPDF(result),
                };

                patient.ClinicalResults.Add(clinRes);

                this.Data.SaveChanges();

                return RedirectToAction("Patients");
            }

            return View(result);
        }


        public ActionResult Delete(int id)
        {
            var result = this.Data.ClinicalResults.GetById(id);

            if (result != null)
            {
                this.Data.ClinicalResults.Delete(result);
                this.Data.SaveChanges();

                return RedirectToAction("ClinicalResults");
            }
            else
            {
                return this.HttpNotFound("There is no Clinical result with such ID!");
            }
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

        [HttpGet]
        public ActionResult AddDoctor()
        {
            AddDoctorViewModel model = new AddDoctorViewModel()
            {
                Specialty = this.Data
                .Specialities
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                })
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddDoctor(AddDoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doc = Mapper.Map<Doctor>(model);
                doc.Image = this.adminService.GetImage(model);
                this.Data.Doctors.Add(doc);
                this.Data.SaveChanges();

                return RedirectToAction("AllDoctors");
            }

            return View(model);
        }

    }
}