using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Entity
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public DateTimeOffset Birthday { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
