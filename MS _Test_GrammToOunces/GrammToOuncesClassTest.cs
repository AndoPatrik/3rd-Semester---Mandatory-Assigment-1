using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrammToOunces;

namespace MS__Test_GrammToOunces
{
    [TestClass]
    public class GrammToOunecsClassTest
    {
        [TestMethod]
        public void GrammToOunecsTest()
        {
            Assert.AreEqual(0.03527396195,GrammToOuncesClass.GrammToOunces(1));
        }

        [TestMethod]
        public void OuncesToGramm()
        {
            Assert.AreEqual(28.34952, GrammToOuncesClass.OuncesToGramm(1));
        }
    }
}
