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

    [TestMethod]
    [DataRow("Pa")]
    public void Rechercher_Mot2CaractèresOuPlus_ReturnListWithCitiesStartsWithParameter(string mot)
    {
        var expected = _villes.Where(v => v.StartsWith(mot)).ToList();

        var result = _recherche.Rechercher(mot);

        CollectionAssert.AreEquivalent(expected, result);
    }

    [TestMethod]
    [DataRow("PA")]
    [DataRow("pA")]
    [DataRow("pa")]
    public void Rechercher_NotCaseSensible_ReturnListNormally(string mot)
    {
        var expected = _villes.Where(v => v.StartsWith(mot, StringComparison.CurrentCultureIgnoreCase)).ToList();

        var result = _recherche.Rechercher(mot);

        CollectionAssert.AreEquivalent(expected, result);
    }
}