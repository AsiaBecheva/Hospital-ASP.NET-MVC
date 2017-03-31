namespace Hospital.Server.Models
{
    using DatabaseModels;
    using Infrastructure.Mapping;

    public class TrialViewModel: IMapFrom<ClinicalTrial>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsAvailable { get; set; }

        public Speciality Speciality { get; set; }

        public decimal Price { get; set; }
    }
} 