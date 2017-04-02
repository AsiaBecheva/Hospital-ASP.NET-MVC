namespace Hospital.Server.Services
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Constants;
    using Data.Repository;
    using DatabaseModels;
    using Models.AdminViewModels;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class AdminService: IAdminService
    {
        private IUnitOfWork Data;

        public AdminService(IUnitOfWork data)
        {
            this.Data = data;
        }

        public List<ResultViewModel> GetAllResults()
        {
            var allresults = this.Data
                .ClinicalResults
                .All()
                .OrderByDescending(x => x.AddedOn)
                .Project()
                .To<ResultViewModel>()
                .ToList();

            return allresults;
        }

        public List<PatientViewModel> GetPatients()
        {
            var patients = this.Data
                .Users
                .All()
                .Where(x => !x.UserName.Contains(GlobalConstants.adminUserName))
                .OrderBy(x => x.UserName)
                .Project()
                .To<PatientViewModel>()
                .ToList();

            return patients;
        }

        public PDF GetPDF(AddResultViewModel result)
        {
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

            return file;
        }

        public Image GetImage(AddDoctorViewModel doctor)
        {
            var file = new Image();

            if (doctor.ImageUpload != null)
            {
                file.FileName = doctor.ImageUpload.FileName;

                using (var memory = new MemoryStream())
                {
                    doctor.ImageUpload.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();
                    file.Content = content;
                }
            }

            return file;
        }
    }
}