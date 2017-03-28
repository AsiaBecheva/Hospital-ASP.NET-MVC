namespace Hospital.DatabaseModels
{
    public class ClinicalTrial
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsAvailable { get; set; }

        public virtual Speciality Speciality { get; set; }

        public decimal Price { get; set; }
    }
}
