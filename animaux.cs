using System;

public abstract class Animal
{
    // Propriétés communes
    public string Genre { get; set; } // "Mâle" ou "Femelle"
    public int AgeMois { get; set; }
    public double Faim { get; set; } // 0 = Repu, 100 = Affamé
    public bool EstMalade { get; set; }
    public bool EnGestation { get; set; }
    public int MoisGestationActuel { get; set; }

    // Propriétés spécifiques à l'espèce (définies dans les constructeurs enfants)
    public abstract int EsperanceVieMois { get; }
    public abstract int MaturiteSexuelleMois { get; }
    public abstract int DureeGestationMois { get; }
    public abstract double ConsommationQuotidienneKg { get; }

    public Animal(string genre, int ageMois)
    {
        Genre = genre;
        AgeMois = ageMois;
        Faim = 0;
        EstMalade = false;
    }

    // Logique de nutrition (basée sur 30 jours par mois)
    public virtual double Manger(double quantiteDisponible)
    {
        double besoinMensuel = ConsommationQuotidienneKg * 30;
        
        if (quantiteDisponible >= besoinMensuel)
        {
            Faim = 0;
            return besoinMensuel;
        }
        else
        {
            Faim += 50; // La faim augmente si le stock est insuffisant
            return quantiteDisponible;
        }
    }

    public void Vieillir()
    {
        AgeMois++;
        if (EnGestation)
        {
            MoisGestationActuel++;
        }
    }

    public bool PeutSeReproduire()
    {
        return AgeMois >= MaturiteSexuelleMois 
               && !EstMalade 
               && Faim < 50 
               && !EnGestation;
    }

    public bool EstVivant()
    {
        if (AgeMois >= EsperanceVieMois) return false;
        if (EstMalade && Faim > 80) return false;
        return true;
    }
}