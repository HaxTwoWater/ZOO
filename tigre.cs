public class Tiger : Animal
{
    public override int LifeExpectancyMonths => 25 * 12;
    public override int SexualMaturityMonths => 4 * 12;
    public override int GestationDurationMonths => 3;
    public override double DailyFoodConsumptionKg => Gender == "Female" ? 10 : 12;
    public override string FoodType => "Meat";

    public Tiger(string gender, int ageInMonths)
        : base("Tiger", gender, ageInMonths) { }
}