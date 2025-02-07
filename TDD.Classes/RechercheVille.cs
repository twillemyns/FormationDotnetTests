namespace TDD.Classes;

public class RechercheVille(List<string> villes)
{
    public List<string> Rechercher(string mot)
    {
        if (mot.Length < 2) throw new NotFoundException();

        throw new NotImplementedException();
    }
}