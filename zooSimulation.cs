using System;
using System.Collections.Generic;
using System.Linq;

public class ZooSimulation
{
    private Random random = new Random();

    public void SimulateOneMonth(Zoo zoo)
    {
        FeedAnimals(zoo);
        HandleDiseases(zoo);
        HandleReproduction(zoo);
        AgeAnimals(zoo);
        RemoveDeadAnimals(zoo);
        CalculateVisitorIncome(zoo);

        zoo.NextMonth();
    }

    private void FeedAnimals(Zoo zoo)
    {
        foreach (Animal animal in zoo.Animals)
        {
            double needed = animal.DailyFoodConsumptionKg * 30;

            if (animal.FoodType == "Meat")
            {
                if (zoo.MeatStock >= needed)
                {
                    zoo.MeatStock -= needed;
                    animal.Hunger = 0;
                }
                else
                {
                    animal.Hunger += 50;
                }
            }
            else
            {
                if (zoo.SeedStock >= needed)
                {
                    zoo.SeedStock -= needed;
                    animal.Hunger = 0;
                }
                else
                {
                    animal.Hunger += 50;
                }
            }
        }
    }

    private void HandleDiseases(Zoo zoo)
    {
        foreach (Animal animal in zoo.Animals)
        {
            double probability = 0;

            if (animal.SpeciesName == "Tiger") probability = 0.3 / 12;
            if (animal.SpeciesName == "Eagle") probability = 0.1 / 12;
            if (animal.SpeciesName == "Chicken") probability = 0.05 / 12;

            if (!animal.IsSick && random.NextDouble() < probability)
            {
                animal.IsSick = true;
            }
        }
    }

    private void HandleReproduction(Zoo zoo)
    {
        List<Animal> newborns = new List<Animal>();

        foreach (Habitat habitat in zoo.Habitats)
        {
            var females = habitat.Animals.Where(a => a.Gender == "Female" && a.CanBreed()).ToList();
            var males = habitat.Animals.Where(a => a.Gender == "Male").ToList();

            if (males.Count == 0) continue;

            foreach (var female in females)
            {
                if (habitat.Animals.Count + newborns.Count >= habitat.Capacity)
                    break;

                if (female.SpeciesName == "Tiger")
                {
                    female.IsPregnant = true;
                }
                else if (female.SpeciesName == "Eagle" && zoo.CurrentMonth == 3)
                {
                    newborns.Add(new Eagle(RandomGender(), 0));
                }
                else if (female.SpeciesName == "Chicken")
                {
                    newborns.Add(new Chicken(RandomGender(), 0));
                }
            }
        }

        zoo.Animals.AddRange(newborns);
    }

    private void AgeAnimals(Zoo zoo)
    {
        foreach (Animal animal in zoo.Animals)
        {
            animal.AgeUp();
        }
    }

    private void RemoveDeadAnimals(Zoo zoo)
    {
        zoo.Animals.RemoveAll(a => !a.IsAlive());

        foreach (var habitat in zoo.Habitats)
        {
            habitat.Animals.RemoveAll(a => !a.IsAlive());
        }
    }

    private void CalculateVisitorIncome(Zoo zoo)
    {
        double income = 0;
        bool highSeason = zoo.CurrentMonth >= 5 && zoo.CurrentMonth <= 9;

        foreach (Animal animal in zoo.Animals)
        {
            double visitors = 0;

            if (animal.SpeciesName == "Tiger")
                visitors = highSeason ? 30 : 5;
            else if (animal.SpeciesName == "Eagle")
                visitors = highSeason ? 15 : 7;
            else if (animal.SpeciesName == "Chicken")
                visitors = highSeason ? 2 : 0.5;

            income += visitors * 60;
        }

        zoo.Money += income;
    }

    private string RandomGender()
    {
        return random.Next(2) == 0 ? "Male" : "Female";
    }
}