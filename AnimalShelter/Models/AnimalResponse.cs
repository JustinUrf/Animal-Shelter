using AnimalShelter.Models;

namespace AnimalShelter
{
  public class AnimalResponse
  {
    public List<Animal> Animals { get; set; } = new List<Animal>();
    public int Pages { get; set; }
    public int CurrentPage { get; set; }
  }
}