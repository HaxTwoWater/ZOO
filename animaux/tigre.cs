public class Tigre : Animal
{
    public override int EsperanceVieMois => 300;
    public override int MaturiteSexuelleMois => 48;
    public override int DureeGestationMois => 3;
    public override double ConsommationQuotidienneKg => 12.0;

    public Tigre(string genre, int ageMois) : base(genre, ageMois) { }

    public int GenererPortee()
    {
        Random rand = new Random();
        return rand.Next(1, 4); 
    }
}
