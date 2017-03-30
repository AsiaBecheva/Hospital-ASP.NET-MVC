namespace Hospital.Server.Models.AdminViewModels
{
    using DatabaseModels;
    using Infrastructure.Mapping;
    using AutoMapper;

    public class PatientViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, PatientViewModel>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id));                                                                                               
        }
    }
}