namespace demo1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public int apartmentID { get; set; }
  
        public Apartment? apartment { get; set; }

    }
}
