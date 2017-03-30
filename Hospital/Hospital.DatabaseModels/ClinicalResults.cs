namespace Hospital.DatabaseModels
{
    using System;

    public class ClinicalResult
    {
        public ClinicalResult()
        {
            this.AddedOn = DateTime.Now;
        }

        public int Id { get; set; }

        public virtual User Patient { get; set; }

        public DateTime AddedOn { get; set; }

        public StatusResult StatusResult { get; set; }

        public virtual PDF File { get; set; }
    }
}
