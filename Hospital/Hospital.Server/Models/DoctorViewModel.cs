namespace Hospital.Server.Models
{
    using AutoMapper;
    using DatabaseModels;
    using Infrastructure.Mapping;

    public class DoctorViewModel: IMapFrom<Doctor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string SpecialityTitle { get; set; }

        public Image Image { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Doctor, DoctorViewModel>()
                .ForMember(x => x.SpecialityTitle, opt => opt.MapFrom(x => x.Specialty.Title));
        }
    }
}