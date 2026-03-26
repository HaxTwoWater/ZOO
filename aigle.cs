public class Eagle : Animal
{
    public override int LifeExpectancyMonths => 25 * 12;
    public override int SexualMaturityMonths => 4 * 12;
    public override int GestationDurationMonths => 2;
    public override double DailyFoodConsumptionKg => Gender == "Female" ? 0.3 : 0.25;
    public override string FoodType => "Meat";

    public Eagle(string gender, int ageInMonths)
        : base("Eagle", gender, ageInMonths) { }
}