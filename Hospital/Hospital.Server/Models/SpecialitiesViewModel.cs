namespace Hospital.Server.Models
{
    using DatabaseModels;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using AutoMapper;

    public class SpecialitiesViewModel: IMapFrom<Speciality>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<ClinicalTrial> ClinicalTrials { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}