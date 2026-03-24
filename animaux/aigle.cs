public class Aigle : Animal
{
    public override int EsperanceVieMois => 168;
    public override int MaturiteSexuelleMois => 48;
    public override int DureeGestationMois => 2; 
    public override double ConsommationQuotidienneKg => 0.25;

    public Aigle(string genre, int ageMois) : base(genre, ageMois) { }
}