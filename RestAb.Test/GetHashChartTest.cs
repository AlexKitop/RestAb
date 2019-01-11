using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestAb.Tests
{
  [TestClass]
  public class GetHashChartTest
  {
    [TestMethod]
    public void TestNull()
    {
      var counter = Helpers.GetHashChart(null);
      Assert.IsTrue(counter.Any(i => i.Value == 0 ));
    }

    [TestMethod]
    public void TesABC()
    {
      var counter = Helpers.GetHashChart("ABCCBA");
      Assert.IsTrue(counter['B'] == 2);
    }

    [TestMethod]
    public void Tes909()
    {
      var counter = Helpers.GetHashChart("909");
      Assert.IsTrue(counter['0'] == 1);
      Assert.IsTrue(counter['9'] == 2);
      Assert.IsTrue(counter['1'] == 0);
    }

  }
}
