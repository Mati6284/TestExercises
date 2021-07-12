using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestowyProjekt.AXA
{
    public class Objects2
    {
        IWebDriver driver; 
        public Objects2(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement searchField => driver.FindElement(By.XPath("//input[@id='searchboxinput']"));
        public IWebElement searchButton => driver.FindElement(By.XPath("//button[@id='searchbox-searchbutton']"));
        public IWebElement buttonCreateRoute => driver.FindElement(By.XPath("//button[@data-value='Wyznacz trasę']"));
        // part B
        public IWebElement buttonRoad => driver.FindElement(By.XPath("//button[@class='searchbox-directions']"));
        public IWebElement startPoint => driver.FindElement(By.XPath("//div[@id='sb_ifc51']//input"));
        public IWebElement searchButtonStartPoint => driver.FindElement(By.XPath("//div[@id='directions-searchbox-0']//button[@class='searchbox-searchbutton']"));
        public IWebElement endPoint => driver.FindElement(By.XPath("//div[@id='sb_ifc52']//input"));
        public IWebElement searchButtonEndPoint => driver.FindElement(By.XPath("//div[@id='directions-searchbox-1']//button[@class='searchbox-searchbutton']"));
        public IWebElement walkButton => driver.FindElement(By.XPath("//div[@data-travel_mode='2']"));
        public IWebElement duration => driver.FindElement(By.XPath("//div[@id='section-directions-trip-0']//div[@class='section-directions-trip-duration']"));
        public IWebElement distance => driver.FindElement(By.XPath("//div[@id='section-directions-trip-0']//div[@class='section-directions-trip-distance section-directions-trip-secondary-text']"));
        public IWebElement bikeButton => driver.FindElement(By.XPath("//div[@data-travel_mode='1']"));
    }
}
