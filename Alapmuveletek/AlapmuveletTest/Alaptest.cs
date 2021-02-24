using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Alapmuveletek;

namespace AlapmuveletTest
{
    [TestClass]
    public class Alaptest
    {
        [TestMethod]
        public void OsszeadasTest()
        {
            //arrange,act,assert
            Alapmuvelet alapmuvelet = new Alapmuvelet();

            //act
            var sut = alapmuvelet.Osszeadas(10, 20);

            //Assert
            Assert.IsNotNull(alapmuvelet);
            Assert.IsNotNull(sut);
            Assert.AreEqual(30, sut);


        }
        [TestMethod]
        public void KivonasTest()
        {
            Alapmuvelet alapmuvelet = new Alapmuvelet();

            var sut = alapmuvelet.Kivonas(20, 10);

            Assert.IsNotNull(alapmuvelet);
            Assert.IsNotNull(sut);
            Assert.AreEqual(10,sut);
        }

        [TestMethod]
        public void SzorzasTest()
        {
            Alapmuvelet alapmuvelet = new Alapmuvelet();
            var sut = alapmuvelet.Szorzas(10, 10);
            Assert.IsNotNull(alapmuvelet);
            Assert.IsNotNull(sut);
            Assert.AreEqual(100, sut);


        }

        [TestMethod]
        public void OsztasTest()
        {
            Alapmuvelet alapmuvelet = new Alapmuvelet();
            var sut = alapmuvelet.Osztas(100, 10);
            Assert.IsNotNull(alapmuvelet);
            Assert.IsNotNull(sut);
            Assert.AreEqual(10, sut);

        }
    }
}
