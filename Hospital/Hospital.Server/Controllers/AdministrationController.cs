namespace Hospital.Server.Controllers
{
    using Data.Constants;
    using Data.Repository;
    using System.Web.Mvc;
    using Models.AdminViewModels;
    using DatabaseModels;
    using Services.Contracts;
    using Services;
    using AutoMapper;

    [Authorize(Roles = GlobalConstants.adminRoleName)]
    public class AdministrationController : BaseController
    {

        private IAdminService adminService;
        private IDoctorService doctorService;
        private ITrialService trialService;

        public AdministrationController(IUnitOfWork data, IAdminService adminService, IDoctorService doctorService,
            ITrialService trialService) : base(data)
        {
            this.adminService = adminService;
            this.doctorService = doctorService;
            this.trialService = trialService;
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
            var model = new AddDoctorViewModel()
            {
                Specialty = adminService.GetSpecialty()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddDoctor(AddDoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var specialty = this.Data.Specialities.GetById(model.SpecialityId);
                var doc = Mapper.Map<Doctor>(model);
                doc.Image = this.adminService.GetImage(model);
                doc.Specialty = specialty;
                this.Data.Doctors.Add(doc);
                this.Data.SaveChanges();

                return RedirectToAction("AllDoctors");
            }

            return View(model);
        }

        
        public ActionResult DeleteDoctor(int id)
        {
            var doc = this.Data.Doctors.GetById(id);

            if (doc == null)
            {
                return HttpNotFound("There is no doctor with such Id");
            }

            this.Data.Doctors.Delete(doc);
            this.Data.SaveChanges();
            return RedirectToAction("AllDoctors");
        }


        public ActionResult AllTrials()
        {
            return View(trialService.GetTrials());
        }

        [HttpGet]
        public ActionResult AddTrial()
        {
            AddTrialViewModel model = new AddTrialViewModel()
            {
                Specialty = this.adminService.GetSpecialty()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddTrial(AddTrialViewModel model)
        {
            if (ModelState.IsValid)
            {
                var specialty = this.Data.Specialities.GetById(model.SpecialityId);
                var trial = Mapper.Map<ClinicalTrial>(model);
                trial.Speciality = specialty;
                this.Data.ClinicalTrials.Add(trial);
                this.Data.SaveChanges();

                return RedirectToAction("AllTrials");
            }

            model.Specialty = this.adminService.GetSpecialty();

            return View(model);
        }



        public ActionResult DeleteTrial(int id)
        {
            var trial = this.Data.ClinicalTrials.GetById(id);

            if (trial == null)
            {
                return HttpNotFound("There is no trial with such Id");
            }

            this.Data.ClinicalTrials.Delete(trial);
            this.Data.SaveChanges();
            return RedirectToAction("AllTrials");
        }
    }
}