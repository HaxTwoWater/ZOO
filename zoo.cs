using System.Collections.Generic;

public class Zoo
{
    public double Money { get; set; }
    public double MeatStock { get; set; }
    public double SeedStock { get; set; }

    public int CurrentMonth { get; set; }
    public int CurrentYear { get; set; }

    public List<Animal> Animals { get; set; }
    public List<Habitat> Habitats { get; set; }

    public Zoo()
    {
        Money = 80000;
        MeatStock = 0;
        SeedStock = 0;
        CurrentMonth = 1;
        CurrentYear = 1;

        Animals = new List<Animal>();
        Habitats = new List<Habitat>();
    }

    public void NextMonth()
    {
        CurrentMonth++;

        if (CurrentMonth > 12)
        {
            CurrentMonth = 1;
            CurrentYear++;
        }
    }
}