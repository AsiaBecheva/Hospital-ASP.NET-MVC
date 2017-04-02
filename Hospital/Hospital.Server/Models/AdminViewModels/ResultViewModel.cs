namespace Hospital.Server.Models.AdminViewModels
{
    using DatabaseModels;
    using Infrastructure.Mapping;
    using System;

    public class ResultViewModel: IMapFrom<ClinicalResult>
    {
        public int Id { get; set; }

        public User Patient { get; set; }

        public DateTime AddedOn { get; set; }

        public StatusResult StatusResult { get; set; }

        public PDF PDF { get; set; }
    }
}