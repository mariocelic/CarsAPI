using System.ComponentModel.DataAnnotations;

namespace Cars.DAL.Entities
{
    public class UserEntity : IUserEntity
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
