using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        
        [Required]
        public string Species { get; set; }

        [Required]
        [Range(0, 40, ErrorMessage = "Cats & dogs don't live longer than 40!.")]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}