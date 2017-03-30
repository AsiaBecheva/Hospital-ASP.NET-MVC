namespace Hospital.Server.Models.AdminViewModels
{
    using DatabaseModels;
    using Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class AddResultViewModel: IMapFrom<ClinicalResult>
    {
        [Display(Name = "Status Result")]
        public StatusResult StatusResult { get; set; }
        
        public User Patient { get; set; }

        public HttpPostedFileBase UploadedFile { get; set; }
    }
}