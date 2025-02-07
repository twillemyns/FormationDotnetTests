using TDD.Classes;

namespace TDD.Tests;

[TestClass]
public class RechercheVilleTests
{
    private List<string> _villes = [];
    private RechercheVille _recherche = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        _villes =
        [
            "Paris", "Lyon", "Marseille", "Toulouse", "Nice", "Nantes", "Strasbourg", "Montpellier", "Bordeaux", "Lille"
        ];

        _recherche = new RechercheVille(_villes);
    }

    [TestMethod]
    public void Rechercher_MotMoinsDe2Caractères_ThrowsNotImplementedException()
    {
        Assert.ThrowsException<NotFoundException>(() => _recherche.Rechercher("P"));
    }
}