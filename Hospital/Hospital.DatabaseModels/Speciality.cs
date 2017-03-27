namespace Hospital.DatabaseModels
{
    using System.Collections.Generic;

    public class Speciality
    {
        private ICollection<ClinicalTrial> clinicalTrials;
        private ICollection<Doctor> doctors;

        public Speciality()
        {
            this.clinicalTrials = new HashSet<ClinicalTrial>();
            this.doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ClinicalTrial> ClinicalTrials
        {
            get { return this.clinicalTrials; }
            set { this.clinicalTrials = value; }
        }

        public virtual ICollection<Doctor> Doctors
        {
            get { return this.doctors; }
            set { this.doctors = value; }
        }
    }
}
