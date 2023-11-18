using System.ComponentModel.DataAnnotations;
namespace tuwiq.Models
{
    public class Cats
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Dbirth {  get; set; }
        public string Description { get; set; }
        public string Price { get; set; }


    }
}
