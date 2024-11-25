namespace CarCRUD.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string NameOfUniversity { get; set; }

        public string NameOfFaculty { get; set; }

        public int Degree { get; set; }
    }
}
