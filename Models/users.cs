using System.ComponentModel.DataAnnotations;

namespace tuwiq.Models
{
    public class users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
