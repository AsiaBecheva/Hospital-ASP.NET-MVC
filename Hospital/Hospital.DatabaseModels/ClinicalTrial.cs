namespace Hospital.DatabaseModels
{
    public class ClinicalTrial
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IsAvailable IsAvailable { get; set; }

        public virtual Speciality Speciality { get; set; }

        public decimal Price { get; set; }
    }
}
