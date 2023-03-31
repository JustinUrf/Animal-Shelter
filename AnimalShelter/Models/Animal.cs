using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    [Required]
    public string Breed { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(0, 100, ErrorMessage = "Age must be between 0 and 100!")]
    public int Age { get; set; }
    [Required]
    public string Color { get; set; }
    [Required]
    public string Gender { get; set; }
  }
}