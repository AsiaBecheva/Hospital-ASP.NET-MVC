namespace Hospital.DatabaseModels
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<ClinicalResult> clinicalResults;

        public User()
        {
            this.clinicalResults = new HashSet<ClinicalResult>();
        }

        public virtual ICollection<ClinicalResult> ClinicalResults
        {
            get { return this.clinicalResults; }
            set { this.clinicalResults = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
