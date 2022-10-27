namespace demo1.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ICollection<User>? users { get; set; }
    }
}
