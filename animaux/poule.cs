public class Poule : Animal
{
    public override int EsperanceVieMois => 96;
    public override int MaturiteSexuelleMois => 6;
    public override double ConsoQuotidienneKg => 0.15;
    public override string TypeAliment => "Graines";

    public Poule(string genre, int ageMois) : base(genre, ageMois) { }

    public int CalculerEclosionsMensuelles()
    {
        if (Genre != "Femelle" || AgeMois < MaturiteSexuelleMois) return 0;

        // 250 oeufs / 12 mois = ~20 oeufs par mois
        int oeufsPondus = 20; 
        int poussins = 0;
        Random rand = new Random();

        for (int i = 0; i < oeufsPondus; i++)
        {
            // 50% de chance d'éclosion
            if (rand.NextDouble() < 0.50) poussins++;
        }
        return poussins;
    }
}