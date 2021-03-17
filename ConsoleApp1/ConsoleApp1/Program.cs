using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://tanlaktanya.taszi.hu";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElement(By.LinkText("Belépés")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("username")).SendKeys("seleniumtest");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("password")).SendKeys("a1234567"+Keys.Enter);
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Programozás")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Szoftverfejlesztő (14d13b)")).Click();

            Thread.Sleep(10000);

            driver.FindElement(By.LinkText("Kilépés")).Click();

            Thread.Sleep(5000);
            
            driver.Close();

            Console.ReadKey();
        }
    }
}
