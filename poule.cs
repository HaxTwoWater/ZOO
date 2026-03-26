public class Chicken : Animal
{
    public override int LifeExpectancyMonths => 8 * 12;
    public override int SexualMaturityMonths => 6;
    public override int GestationDurationMonths => 2;
    public override double DailyFoodConsumptionKg => Gender == "Female" ? 0.15 : 0.18;
    public override string FoodType => "Seeds";

    public Chicken(string gender, int ageInMonths)
        : base("Chicken", gender, ageInMonths) { }
}