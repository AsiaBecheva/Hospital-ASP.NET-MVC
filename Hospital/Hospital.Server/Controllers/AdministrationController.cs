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
    using Services.Contracts;

    [Authorize(Roles = GlobalConstants.adminRoleName)]
    public class AdministrationController : BaseController
    {

        private IAdminService adminService;

        public AdministrationController(IUnitOfWork data, IAdminService adminService) : base(data)
        {
            this.adminService = adminService;
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
                var patient = this.Data.Users
                    .GetById(result.PatientId);

                var file = new PDF();

                if (result.UploadedFile != null)
                {
                    file.FileName = result.UploadedFile.FileName;

                    using (var memory = new MemoryStream())
                    {
                        result.UploadedFile.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();
                        file.Content = content;
                    }
                }

                var clinRes = new ClinicalResult()
                {
                    StatusResult = result.StatusResult,
                    File = file,
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
    }
}