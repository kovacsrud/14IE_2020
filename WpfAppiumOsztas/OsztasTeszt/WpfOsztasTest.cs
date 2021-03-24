using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using System;

namespace OsztasTeszt
{
    public class Tests
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";

        private const string WpfProgramId = @"G:\tavtanitas\kodtarak\14IE_2020\WpfAppiumOsztas\WpfAppiumOsztas\bin\Debug\WpfAppiumOsztas.exe";

        private const string WpfProgramPath= @"G:\tavtanitas\kodtarak\14IE_2020\WpfAppiumOsztas\WpfAppiumOsztas\bin\Debug\";

        protected static WindowsDriver<WindowsElement> driver;


        [OneTimeSetUp]
        public void Setup()
        {
            if (driver==null)
            {
                var appiumoptions = new AppiumOptions();
                appiumoptions.AddAdditionalCapability("app",WpfProgramId);
                appiumoptions.AddAdditionalCapability("deviceName","WindowsPC");
                driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl),appiumoptions);
            }
        }

        [Test]
        public void OsztasTest()
        {
            var aErtek = driver.FindElementByAccessibilityId("textboxA");
            var bErtek = driver.FindElementByAccessibilityId("textboxB");
            var eredmeny = driver.FindElementByAccessibilityId("textblockEredmeny");
            aErtek.Clear();
            bErtek.Clear();
            eredmeny.Clear();
            aErtek.SendKeys("10");
            bErtek.SendKeys("5");
            driver.FindElementByAccessibilityId("buttonSzamol").Click();
            eredmeny = driver.FindElementByAccessibilityId("textblockEredmeny");
            Assert.AreEqual(2,Convert.ToDouble(eredmeny.Text));

        }
    }
}