using NUnit.Framework;
using Alapmuveletek;

namespace NUnitAlapTest
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OsszeadasTest()
        {
            Alapmuvelet alapmuvelet = new Alapmuvelet();
            var sut = alapmuvelet.Osszeadas(10, 20);
            Assert.IsNotNull(alapmuvelet);
            Assert.IsNotNull(sut);
            Assert.AreEqual(30, sut);
            
        }
    }
}