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
            "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney",
            "New York", "Londres", "Bangkok", "Hong Kong", "Dubaï", "Rome", "Istanbul"
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

    [TestMethod]
    [DataRow("ape")]
    public void Rechercher_MotFaisantPartieDeLaVille_ReturnShortList(string mot)
    {
        var expected = _villes.Where(v => v.Contains(mot, StringComparison.InvariantCultureIgnoreCase)).ToList();

        var result = _recherche.Rechercher(mot);

        CollectionAssert.AreEquivalent(expected, result);
    }

    [TestMethod]
    [DataRow("*")]
    public void Rechercher_MotEgalEtoile_ReturnAllCities(string mot)
    {
        var expected = _villes;

        var result = _recherche.Rechercher(mot);

        CollectionAssert.AreEquivalent(expected, result);
    }
}