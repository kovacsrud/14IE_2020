using NUnit.Framework;
using Sikidomok;
using System;
using System.Collections.Generic;
using System.IO;

namespace NUnitSikidomTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test,TestCaseSource("GetTesztAdat")]

        
        public void TeglalapKeruletTest(double aoldal,double boldal,double elvart)
        {
            //Arrange
            Sikidom sikidom = new Sikidom();

            //Act
            var sut = sikidom.TeglalapKerulet(aoldal, boldal);

            //Assert
            Assert.IsNotNull(sikidom);
            Assert.IsNotNull(sut);
            Assert.AreEqual(elvart, sut);
        }

        public static IEnumerable<double[]> GetTesztAdat()
        {
            var sorok = File.ReadAllLines("teglalap_tesztadat.csv");
            for (int i = 0; i < sorok.Length; i++)
            {
                var e = sorok[i].Split(';');
                double aoldal = Convert.ToDouble(e[0]);
                double boldal = Convert.ToDouble(e[1]);
                double elvart = Convert.ToDouble(e[2]);
                yield return new[] { aoldal, boldal, elvart };
            }
        }
    }
}