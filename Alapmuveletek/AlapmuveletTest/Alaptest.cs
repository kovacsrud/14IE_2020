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
            Assert.AreEqual(30, sut);


        }
    }
}
