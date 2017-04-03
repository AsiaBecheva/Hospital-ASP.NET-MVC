namespace Hospital.Server.Models
{
    using AutoMapper;
    using DatabaseModels;
    using Infrastructure.Mapping;

    public class TrialViewModel: IMapFrom<ClinicalTrial>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IsAvailable IsAvailable { get; set; }

        public string SpecialityTitle { get; set; }

        public Speciality Speciality { get; set; }

        public decimal Price { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ClinicalTrial, TrialViewModel>()
                .ForMember(x => x.SpecialityTitle, opt => opt.MapFrom(x => x.Speciality.Title));
        }
    }
} 