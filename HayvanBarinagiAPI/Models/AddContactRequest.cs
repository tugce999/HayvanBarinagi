namespace HayvanBarinagiAPI.Models
{
    public class AddContactRequest
    {
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public long Phone { get; set; }
        public string Adress { get; set; }
    }
}
