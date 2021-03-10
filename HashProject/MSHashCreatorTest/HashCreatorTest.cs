using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HashCreator;

namespace MSHashCreatorTest
{
    [TestClass]
    public class HashCreatorTest
    {
        [TestMethod]
        [DataRow("22e67b691bcc1bb1c806364fb660294e", "Valami szöveg")]
        [DataRow("3c10c2eabdbda72710357ba04f8a2941", @"g:\toyota.jpg")]
        public void TestMd5(string elvart,string szoveg)
        {
            HashCreate hash = new HashCreate();
            var sut = hash.CreateHash(HashType.MD5, szoveg);
            Assert.AreEqual(elvart, sut);
        }
    }
}
