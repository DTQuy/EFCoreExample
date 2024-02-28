using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Entity
{
    /// <summary>
    /// Represents a user entity.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the user
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password of the user
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the user's email is confirmed
        /// </summary>
        public bool EmailConfirmed { get; set; } = false;

        /// <summary>
        /// Gets or sets the details of the user
        /// </summary>
        public UserDetails? UserDetails { get; set; }

        /// <summary>
        /// Gets or sets the list of orders associated with this user
        /// </summary>
        public List<UserOrder>? UserOrders { get; set; }
    }
}
