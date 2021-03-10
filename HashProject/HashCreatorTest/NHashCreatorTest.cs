using NUnit.Framework;
using HashCreator;

namespace HashCreatorTest
{
    public class NunitHashCreatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("22e67b691bcc1bb1c806364fb660294e","Valami szöveg")]
        [TestCase("3c10c2eabdbda72710357ba04f8a2941", @"g:\toyota.jpg")]
        public void NunitMd5Test(string elvart,string szoveg)
        {
            HashCreate hash = new HashCreate();
            var sut = hash.CreateHash(HashType.MD5,szoveg);
            Assert.AreEqual(elvart, sut);
        }

        [Test]
        [TestCase("E12C169414ED5747B42C02ACC432E409AD684162", "Valami szöveg")]
        [TestCase("81B71216BEA6BDA6789A11099CAAE0DEA72AC109", @"g:\toyota.jpg")]
        public void NunitSha1Test(string elvart,string szoveg)
        {
            HashCreate hash = new HashCreate();
            var sut = hash.CreateHash(HashType.SHA1, szoveg);
            Assert.AreEqual(elvart.ToLower(), sut);
        }
    }
}