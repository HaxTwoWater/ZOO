public class Aigle : Animal
{
    public override int EsperanceVieMois => 168;
    public override int MaturiteSexuelleMois => 48;
    public override int DureeGestationMois => 2; 
    public override double ConsommationQuotidienneKg => 0.25;

    public Aigle(string genre, int ageMois) : base(genre, ageMois) { }

public int CalculerEclosionsMensuelles(int moisActuel)
    {
        // 1. L'aigle ne pond qu'en Mars (Mois 3)
        if (moisActuel != 3) return 0;

        // 2. Uniquement pour les femelles matures et en bonne santé
        if (Genre != "Femelle" || AgeMois < MaturiteSexuelleMois || EstMalade) return 0;

        int oeufsPondus = 2; // Fixe pour l'aigle
        int aiglons = 0;
        Random rand = new Random();

        for (int i = 0; i < oeufsPondus; i++)
        {
            // 50% de chance d'éclosion
            if (rand.NextDouble() < 0.50) aiglons++;
        }
        return aiglons;
    }
}
