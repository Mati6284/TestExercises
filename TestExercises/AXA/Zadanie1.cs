using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace TestowyProjekt.AXA
{
    class Zadanie1
    {
        IWebDriver driver; //wymagana instalacja paczki
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
        }

        [Test]
        public void BirthPlace()
        {
            driver.Navigate().GoToUrl("https://swapi.dev/");
            string jsonLukeSkywalker = driver.FindElement(By.XPath("//pre[@id='interactive_output']")).GetAttribute("innerText");
            var person = JsonConvert.DeserializeObject<Person>(jsonLukeSkywalker);  //wymagana instalacja paczki
            //klasy do JSON-ów generowane przy użyciu https://app.quicktype.io/
            string planetRequest = string.Concat(person.Homeworld).Substring(22);

            IWebElement input = driver.FindElement(By.XPath("//input[@id='interactive']"));     //zapytanie dla pobranej ścieżki planety
            input.Click();
            input.SendKeys(planetRequest);
            IWebElement buttonRequest = driver.FindElement(By.XPath("//button[@class='btn btn-primary']"));
            buttonRequest.Click();
            Thread.Sleep(1000);
            string jsonPlanet = driver.FindElement(By.XPath("//pre[@id='interactive_output']")).GetAttribute("innerText");
            var planet = JsonConvert.DeserializeObject<Planet>(jsonPlanet);
            string birthPlace = string.Concat(planet.Name);
            Assert.AreEqual("Tatooine", birthPlace);
            
        }

        [TearDown]
        public void Ending()
        {
            driver.Quit();
        }

    }
}
