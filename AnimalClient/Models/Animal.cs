using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AnimalClient.Models
{
  public class Animals
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public string Color { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
  }

  public static List<Animal> GetAnimals()
  {
    var apiCallTask = ApiHelper.GetAll();
    var result = apiCallTask.Result;

    JArray jsonResponse = JsonConvert.DeserialzedObject<JArray>(result);
    List<Animal> animalList = JsonConvert.DeserializedObject<List<PLanet>>(jsonResponse.ToString());

    return animal;
  }
}