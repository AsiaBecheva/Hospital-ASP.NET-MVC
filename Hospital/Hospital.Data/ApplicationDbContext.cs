namespace Hospital.Data
{
    using DatabaseModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<ClinicalResult> ClinicalResults { get; set; }
        public virtual IDbSet<Doctor> Doctors { get; set; }
        public virtual IDbSet<Image> Images { get; set; }
        public virtual IDbSet<ClinicalTrial> ClinicalTrials { get; set; }
        public virtual IDbSet<Speciality> Specialities { get; set; }
        public virtual IDbSet<PDF> PDFs { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
