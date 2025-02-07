namespace TDD.Classes;

public class RechercheVille(List<string> villes)
{
    public List<string> Rechercher(string mot)
    {
        if (mot == "*") return villes;

        return mot.Length switch
        {
            < 2 => throw new NotFoundException(),
            >= 2 => villes.Where(v => v.Contains(mot, StringComparison.InvariantCultureIgnoreCase)).ToList()
        };
    }
}