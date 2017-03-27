namespace Hospital.DatabaseModels
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Speciality Specialty { get; set; }

        public Image Image { get; set; }

        public string Description { get; set; }
    }
}
