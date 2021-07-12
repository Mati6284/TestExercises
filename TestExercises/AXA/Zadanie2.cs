using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestowyProjekt.AXA
{
    class Zadanie2
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            objects = new Objects2(driver);
        }

        Objects2 objects;
        
        [Test]
        public void RoadTestA()
        {
            driver.Navigate().GoToUrl("https://www.google.pl/maps/");
            driver.FindElement(By.XPath("//span[text()='Zgadzam się']")).Click();    //Google Agreement 
            objects.searchField.Click();
            objects.searchField.SendKeys("Chłodna 51, Warszawa");     //wyszukanie celu do nawigacji
            objects.searchButton.Click();
            objects.buttonCreateRoute.Click();
            objects.startPoint.SendKeys("Plac Defilad 1, Warszawa");    //Adres startowy
            objects.searchButtonStartPoint.Click();

            objects.walkButton.Click();     //wybór opcji 'pieszo'            
            string walkTimeText = objects.duration.GetAttribute("innerText").Substring(0, 2);
            string walkDistanceText = objects.distance.GetAttribute("innerText").Substring(0, 3);
            int walkTime = Int32.Parse(walkTimeText);
            double walkDistance = Double.Parse(walkDistanceText.Replace(',', '.'));

            Thread.Sleep(1000);
            objects.bikeButton.Click();     //wybór opcji rowerem
            string bikeTimeText = objects.duration.GetAttribute("innerText").Substring(0, 2);
            string bikeDistanceText = objects.distance.GetAttribute("innerText").Substring(0, 2);
            int bikeTime = Int32.Parse(bikeTimeText);
            double bikeDistance = Double.Parse(bikeDistanceText.Replace(',', '.'));

            Assert.LessOrEqual(walkTime, 40, "Warunki niespełnione");
            Assert.LessOrEqual(walkDistance, 3, "Warunki niespełnione");
            Assert.LessOrEqual(bikeTime, 15, "Warunki niespełnione");
            Assert.LessOrEqual(bikeDistance, 3, "Warunki niespełnione");
            if (walkTime < 40 && walkDistance < 3)
            {
                Console.WriteLine("Czas drogi pieszo jest krótszy niż 40 minut, a dystans mniejszy niż 3 km \n Czas wynosi: " + walkTime + " min, a droga: " + walkDistance + " km.");
            }

            if (bikeTime < 15 && bikeDistance < 3)
            {
                Console.WriteLine("Czas drogi rowerem jest krótszy niż 15 minut, a dystans mniejszy niż 3 km \n Czas wynosi: " + bikeTime + " min, a droga: " + bikeDistance + " km.");
            }

        }
        
        [Test]
        public void RoadTestB()
        {
            driver.Navigate().GoToUrl("https://www.google.pl/maps/");
            driver.FindElement(By.XPath("//span[text()='Zgadzam się']")).Click();    //Google Agreement             
            objects.buttonRoad.Click();            
            objects.startPoint.Click();
            objects.startPoint.SendKeys("Plac Defilad 1, Warszawa");    //Adres startowy
            objects.searchButtonStartPoint.Click();
            objects.endPoint.Click();
            objects.endPoint.SendKeys("Chłodna 51, Warszawa");  //Adres końcowy
            objects.searchButtonEndPoint.Click();
            
            objects.walkButton.Click();     //wybór opcji 'pieszo'            
            string walkTimeText = objects.duration.GetAttribute("innerText").Substring(0,2);
            string walkDistanceText = objects.distance.GetAttribute("innerText").Substring(0,3);
            int walkTime = Int32.Parse(walkTimeText);
            double walkDistance = Double.Parse(walkDistanceText.Replace(',', '.'));
            
            Thread.Sleep(1000);
            objects.bikeButton.Click();     //wybór opcji rowerem
            string bikeTimeText = objects.duration.GetAttribute("innerText").Substring(0,2);
            string bikeDistanceText = objects.distance.GetAttribute("innerText").Substring(0, 2);
            int bikeTime = Int32.Parse(bikeTimeText);
            double bikeDistance = Double.Parse(bikeDistanceText.Replace(',', '.'));

            Assert.LessOrEqual(walkTime, 40, "Warunki niespełnione");
            Assert.LessOrEqual(walkDistance, 3, "Warunki niespełnione");
            Assert.LessOrEqual(bikeTime, 15, "Warunki niespełnione");
            Assert.LessOrEqual(bikeDistance, 3, "Warunki niespełnione");
            if (walkTime < 40 && walkDistance < 3)
            {
                Console.WriteLine("Czas drogi pieszo jest krótszy niż 40 minut, a dystans mniejszy niż 3 km \n Czas wynosi: " + walkTime + " min, a droga: " + walkDistance + " km.");
            }
            
            if (bikeTime < 15 && bikeDistance < 3)
            {
                Console.WriteLine("Czas drogi rowerem jest krótszy niż 15 minut, a dystans mniejszy niż 3 km \n Czas wynosi: " + bikeTime + " min, a droga: " + bikeDistance + " km.");
            }
            
        }
        
        [TearDown]
        public void TestEnding()
        {
            driver.Quit();
        }
    }
}
