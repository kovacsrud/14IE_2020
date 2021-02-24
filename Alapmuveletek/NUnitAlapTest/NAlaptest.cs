using NUnit.Framework;
using Alapmuveletek;
using System;

namespace NUnitAlapTest
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase(10,20,30)]
        [TestCase(11, 22, 33)]
        [TestCase(21, 20, 41)]
        [TestCase(33, 22, 55)]
        public void OsszeadasTest(double a,double b,double elvart)
        {
            Alapmuvelet alapmuvelet = new Alapmuvelet();
            var sut = alapmuvelet.Osszeadas(a, b);
            Assert.IsNotNull(alapmuvelet);
            Assert.IsNotNull(sut);
            Assert.AreEqual(elvart, sut);
            
        }

        [Test]
        [TestCase(20,10,2)]
        [TestCase(40,10,4)]
        
        public void OsztasTest(double a,double b,double elvart)
        {
            Alapmuvelet alapmuvelet = new Alapmuvelet();
            var sut = alapmuvelet.Osztas(a, b);
            Assert.IsNotNull(alapmuvelet);
            Assert.IsNotNull(sut);
            Assert.AreEqual(elvart, sut, 0.03);
        }

        [Test]
        [TestCase(10,0)]
        public void OsztasKivetelTest(double a,double b)
        {
            Alapmuvelet alapmuvelet = new Alapmuvelet();
            
            Assert.Throws<ArgumentException>(()=>alapmuvelet.Osztas(a,b));
        }
    }
}