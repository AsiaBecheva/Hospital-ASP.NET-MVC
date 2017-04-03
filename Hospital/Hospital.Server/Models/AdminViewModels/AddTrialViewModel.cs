namespace Hospital.Server.Models.AdminViewModels
{
    using AutoMapper;
    using DatabaseModels;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class AddTrialViewModel: IMapFrom<ClinicalTrial>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public IsAvailable IsAvailable { get; set; }

        public int SpecialityId { get; set; }

        public IEnumerable<SelectListItem> Specialty { get; set; }

        public decimal Price { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ClinicalTrial, AddTrialViewModel>()
                .ForMember(x => x.SpecialityId, opt => opt.MapFrom(x => x.Speciality.Id))
                .ReverseMap();
        }
    }
}