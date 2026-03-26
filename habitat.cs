using System.Collections.Generic;

public class Habitat
{
    public string HabitatType { get; set; }
    public int Capacity { get; set; }
    public double DiseaseProbability { get; set; }
    public int OverpopulationLoss { get; set; }

    public List<Animal> Animals { get; set; }

    public Habitat(string habitatType, int capacity, double diseaseProbability, int overpopulationLoss)
    {
        HabitatType = habitatType;
        Capacity = capacity;
        DiseaseProbability = diseaseProbability;
        OverpopulationLoss = overpopulationLoss;
        Animals = new List<Animal>();
    }

    public bool AddAnimal(Animal animal)
    {
        if (Animals.Count >= Capacity) return false;

        if (HabitatType == "Tiger" && animal.SpeciesName != "Tiger") return false;
        if (HabitatType == "Eagle" && animal.SpeciesName != "Eagle") return false;
        if (HabitatType == "Chicken" && animal.SpeciesName != "Chicken") return false;

        Animals.Add(animal);
        return true;
    }

    public void RemoveAnimal(Animal animal)
    {
        Animals.Remove(animal);
    }
}