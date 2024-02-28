using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Entity
{
    /// <summary>
    /// Represents user details entity.
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the avatar URL.
        /// </summary>
        public string Avatar { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the age of the user.
        /// </summary>
        public int Age { get; set; } = 0;

        /// <summary>
        /// Gets or sets the birthday of the user.
        /// </summary>
        public DateTimeOffset Birthday { get; set; }

        /// <summary>
        /// Gets or sets the ID of the associated user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with these details.
        /// </summary>
        public User? User { get; set; }
    }
}
