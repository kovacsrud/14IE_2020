using NUnit.Framework;
using HashCreator;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace HashCreatorTest
{
    public class NunitHashCreatorTests

    {
        protected static ExtentReports extReport;
        protected static ExtentTest extTest;

        [SetUp]
        public void Setup()
        {
        }

        [OneTimeSetUp]

        public static void ReportSetup()
        {
            extReport = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"g:\14ie_extrep\");
            extReport.AddSystemInfo("Hash tesztelés","Hash tesztelés");
            extReport.AddSystemInfo("Tesztelõ:","KR");
            extReport.AttachReporter(htmlreporter);
            htmlreporter.Config.DocumentTitle = "HTML teszt riport";
            htmlreporter.Config.ReportName = "Hash tesztek";
            htmlreporter.Config.Theme = Theme.Standard;
        }

        [Test]
        [TestCase("22e67b691bcc1bb1c806364fb660294e","Valami szöveg")]
        [TestCase("3c10c2eabdbda72710357ba04f8a2941", @"g:\toyota.jpg")]
        public void NunitMd5Test(string elvart,string szoveg)
        {
            extTest = extReport.CreateTest("MD5 teszt");
            HashCreate hash = new HashCreate();
            var sut = hash.CreateHash(HashType.MD5,szoveg);
            Assert.AreEqual(elvart, sut);
            extTest.Log(Status.Pass,"MD5 teszt sikeres");
        }

        [Test]
        [TestCase("E12C169414ED5747B42C02ACC432E409AD684162", "Valami szöveg")]
        [TestCase("81B71216BEA6BDA6789A11099CAAE0DEA72AC109", @"g:\toyota.jpg")]
        public void NunitSha1Test(string elvart,string szoveg)
        {
            extTest = extReport.CreateTest("SHA1 teszt");
            HashCreate hash = new HashCreate();
            var sut = hash.CreateHash(HashType.SHA1, szoveg,true);
            Assert.AreEqual(elvart, sut);
            extTest.Log(Status.Pass,"SHA1 teszt sikeres");
        }

        [OneTimeTearDown]
        public static void EndReport()
        {
            extReport.Flush();
        }
    }
}