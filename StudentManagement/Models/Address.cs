namespace StudentManagement.Models
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public Address(string city, string street, string number)
        {
            City = city;
            Street = street;
            Number = number;
        }
    }
}
