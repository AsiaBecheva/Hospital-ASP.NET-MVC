namespace Hospital.Server.Models
{
    using DatabaseModels;
    using Infrastructure.Mapping;
    using System;
    using AutoMapper;

    public class PatientResultViewModel:  IMapFrom<ClinicalResult>
    {
        public int Id { get; set; }

        public DateTime AddedOn { get; set; }

        public StatusResult StatusResult { get; set; }

        public FileBase PDF { get; set; }
    }
}