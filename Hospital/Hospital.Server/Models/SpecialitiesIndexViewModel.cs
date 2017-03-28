namespace Hospital.Server.Models
{
    using DatabaseModels;
    using Infrastructure.Mapping;
    using System.Collections.Generic;

    public class SpecialitiesIndexViewModel: IMapFrom<Speciality>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<ClinicalTrial> ClinicalTrials { get; set; }
    }
}