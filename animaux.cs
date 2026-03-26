public abstract class Animal
{
    public string SpeciesName { get; set; }
    public string Gender { get; set; }
    public int AgeInMonths { get; set; }
    public double Hunger { get; set; }
    public bool IsSick { get; set; }
    public bool IsPregnant { get; set; }
    public int CurrentPregnancyMonths { get; set; }
    public bool CanBreedThisMonth { get; set; }

    public abstract int LifeExpectancyMonths { get; }
    public abstract int SexualMaturityMonths { get; }
    public abstract int GestationDurationMonths { get; }
    public abstract double DailyFoodConsumptionKg { get; }
    public abstract string FoodType { get; }

    public Animal(string speciesName, string gender, int ageInMonths)
    {
        SpeciesName = speciesName;
        Gender = gender;
        AgeInMonths = ageInMonths;
        Hunger = 0;
        IsSick = false;
        IsPregnant = false;
        CurrentPregnancyMonths = 0;
        CanBreedThisMonth = true;
    }

    public virtual void AgeUp()
    {
        AgeInMonths++;

        if (IsPregnant)
        {
            CurrentPregnancyMonths++;
        }
    }

    public virtual bool IsAlive()
    {
        if (AgeInMonths >= LifeExpectancyMonths) return false;
        if (Hunger >= 100) return false;
        return true;
    }

    public virtual bool CanBreed()
    {
        return AgeInMonths >= SexualMaturityMonths
               && !IsSick
               && Hunger < 50
               && !IsPregnant
               && CanBreedThisMonth;
    }
}