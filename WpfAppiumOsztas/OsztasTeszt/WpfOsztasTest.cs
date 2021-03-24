using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework.Interfaces;

namespace OsztasTeszt
{
    public class Tests
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";

        private const string WpfProgramId = @"G:\tavtanitas\kodtarak\14IE_2020\WpfAppiumOsztas\WpfAppiumOsztas\bin\Debug\WpfAppiumOsztas.exe";

        private const string WpfProgramPath= @"G:\tavtanitas\kodtarak\14IE_2020\WpfAppiumOsztas\WpfAppiumOsztas\bin\Debug\";

        protected static WindowsDriver<WindowsElement> driver;
        protected static ExtentReports extReport;
        protected static ExtentTest extTest;


        [OneTimeSetUp]
        public static void Setup()
        {
            if (driver==null)
            {
                var appiumoptions = new AppiumOptions();
                appiumoptions.AddAdditionalCapability("app",WpfProgramId);
                appiumoptions.AddAdditionalCapability("deviceName","WindowsPC");
                driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl),appiumoptions);
            }
        }

        [OneTimeSetUp]
        public static void ReportSetup()
        {
            extReport = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"G:\14ie_extrep\");
            extReport.AddSystemInfo("WPF test", "Auto teszt");
            extReport.AddSystemInfo("Tesztelõ:", "KR");
            extReport.AttachReporter(htmlReporter);
            htmlReporter.Config.DocumentTitle = "HTML teszt riport";
            htmlReporter.Config.ReportName = "Osztás autoteszt";
            htmlReporter.Config.Theme = Theme.Standard;
        }

        [Test]
        [TestCase(4,2,2)]
        [TestCase(12, 2, 6)]
        [TestCase(1, 2, 0.5)]
        [TestCase(222, 2, 111)]
        [TestCase(10, 2, 5)]
        [TestCase(56.5, 2, 28.25)]
        
        public void OsztasTest(double a,double b,double elvart)
        {
            extTest = extReport.CreateTest("Osztás felületi teszt");
            var aErtek = driver.FindElementByAccessibilityId("textboxA");
            var bErtek = driver.FindElementByAccessibilityId("textboxB");
            var eredmeny = driver.FindElementByAccessibilityId("textblockEredmeny");
            aErtek.Clear();
            bErtek.Clear();
            eredmeny.Clear();
            aErtek.SendKeys(Convert.ToString(a));
            bErtek.SendKeys(Convert.ToString(b));
            driver.FindElementByAccessibilityId("buttonSzamol").Click();
            eredmeny = driver.FindElementByAccessibilityId("textblockEredmeny");
            Assert.AreEqual(elvart,Convert.ToDouble(eredmeny.Text));
            extTest.Log(Status.Pass,"Osztás teszt rendben");

        }

        [TearDown]
        public static void CloseReport()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;
            var errormsg = TestContext.CurrentContext.Result.Message;
            if (status==TestStatus.Failed)
            {
                ITakesScreenshot shot = (ITakesScreenshot)driver;
                var a = TestContext.CurrentContext.Test.Arguments.GetValue(0);
                var b = TestContext.CurrentContext.Test.Arguments.GetValue(1);
                var elvart = TestContext.CurrentContext.Test.Arguments.GetValue(2);
                string fajlnev = a + "_" + b + "_" + elvart;
                Screenshot screenshot = shot.GetScreenshot();
                screenshot.SaveAsFile(@"g:\14ie_extrep\"+fajlnev+".png",ScreenshotImageFormat.Png);
                
                extTest.Log(Status.Fail,"Hiba!");
                extTest.Log(Status.Fail,stacktrace);
                extTest.Log(Status.Fail, errormsg);
                extTest.Log(Status.Fail, "Képernyõ mentés:");
                extTest.AddScreenCaptureFromPath(fajlnev + ".png");
            }
        }


        [OneTimeTearDown]
        public static void EndTest()
        {
            extReport.Flush();
        }
    }
}