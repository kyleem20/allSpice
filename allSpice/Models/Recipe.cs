using System.ComponentModel.DataAnnotations;

namespace allSpice.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CreatorId { get; set; }
    }
}