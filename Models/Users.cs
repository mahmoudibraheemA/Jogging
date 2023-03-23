namespace MagicVilla.Models
{
    public class Users
    {
        public Guid id { get; set; }
        public Roles Role { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
