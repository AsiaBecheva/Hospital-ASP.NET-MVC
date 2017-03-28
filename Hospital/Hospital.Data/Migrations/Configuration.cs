namespace Hospital.Data.Migrations
{
    using Constants;
    using DatabaseModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        private const string adminRoleName = "AsyaAdmin";
        private const string adminPassword = "AsyaAdmin";


        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedAdmin(context);
            this.SeedDoctorsClinicalTrialsAndSpecialties(context);
        }



        private void SeedAdmin(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            if (!roleManager.RoleExists(adminRoleName))
            {
                var role = new IdentityRole()
                {
                    Name = adminRoleName
                };
                roleManager.Create(role);

                var user = new User()
                {
                    UserName = "asya@gmail.com",
                    Email = "asya@gmail.com"
                };

                IdentityResult createUserResult = userManager.Create(user, adminPassword);
                if (createUserResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, adminRoleName);
                }
            }
        }


        private void SeedDoctorsClinicalTrialsAndSpecialties(ApplicationDbContext context)
        {
            var random = new GenerateRandomData();

            if (!context.Doctors.Any() || !context.ClinicalTrials.Any() || !context.Specialities.Any())
            {
                for (int i = 1; i < 11; i++)
                {
                    var clinicalTrial = new ClinicalTrial
                    {
                        Title = "Trial - " + i + ".1",
                        Price = random.RandomDataInt(25, 4587),
                        IsAvailable = true,
                    };

                    var clinicalTrial2 = new ClinicalTrial
                    {
                        Title = "Trial - " + i + ".2",
                        Price = random.RandomDataInt(48, 565),
                        IsAvailable = false,
                    };

                    var listDoctors = new List<Doctor>();
                    for (int j = 0; j < random.RandomDataInt(2, 6); j++)
                    {
                        var doctor = new Doctor
                        {
                            Name = "Doctor - " + random.RandomDataString(6, 10) + " " + random.RandomDataString(10, 13),
                            Image = CreateImage(),
                            Description = random.RandomDataString(100, 300)
                        };
                        listDoctors.Add(doctor);
                    }

                    var specialty = new Speciality
                    {
                        Title = "Specialty - " + i,
                        Description = random.RandomDataString(200, 500),
                        ClinicalTrials = new HashSet<ClinicalTrial>()
                        {
                            clinicalTrial,
                            clinicalTrial2
                        },
                        Doctors = listDoctors
                    };
                    context.Specialities.Add(specialty);
                    context.SaveChanges();
                }
            }
        }

        private Image CreateImage()
        {
            var img = new Image()
            {
                FileName = "doctor",
                Path = PathConstants.PathImage  
            };

            return img;
        }
    }
}
