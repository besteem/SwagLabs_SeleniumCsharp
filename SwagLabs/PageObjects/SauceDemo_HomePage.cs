using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;

namespace SwagLabs.PageObjects
{
    public class SauceDemo_HomePage
    {
        public IWebDriver driver;

        //locators
        public By homepageHeader = By.XPath("//*[@class = 'product_label']");
        public By hamburgerMenu = By.XPath("//*[contains(@class, 'bm-burger-button')]");
        public By logoutLink = By.XPath("//*[@id = 'logout_sidebar_link']");
        public By allItemsLink = By.XPath("//*[@id='inventory_sidebar_link']");
        public By aboutLink = By.XPath("//*[@id='about_sidebar_link']");
        public By resetAppLink = By.XPath("//*[@id='reset_sidebar_link']");

        public SauceDemo_HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Description: Get the header text of homepge
        public string GetHeaderText()
        {
            return driver.FindElement(homepageHeader).Text;
        }

        /*Description: Verify current URL 
        return true - URL is https://www.saucedemo.com/inventory.html
        return false - URL is not https://www.saucedemo.com/inventory.html
        */
        public bool IsNavigatedToHomePage()
        {
            string currentUrl = driver.Url;
            if(currentUrl == "https://www.saucedemo.com/inventory.html")
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        //Description: Logout from site
        public void LogoutFromSite()
        {
            var IsInHomePage = IsNavigatedToHomePage();
            if (IsInHomePage == true)
            {
                ClickHamburgerMenu();
                ClickLinkInHamburgerMenu(3);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
        }

        //Description: Click Hamburger Menu
        public void ClickHamburgerMenu()
        {
            driver.FindElement(hamburgerMenu).Click();
        }

        /*Description: Click link on Hamburger Menu
        int 1 - ALL ITEMS link
        int 2 - ABOUT link
        int 3 - LOGOUT link
        int 4 - RESET APP STATE link
        */
        public void ClickLinkInHamburgerMenu(int linkId)
        {
            switch (linkId)
            {
                //ALL ITEMS link
                case 1: 
                    driver.FindElement(allItemsLink).Click();
                    break;
                //ABOUT link
                case 2:
                    driver.FindElement(aboutLink).Click();
                    break;
                //LOGOUT link
                case 3:
                    driver.FindElement(logoutLink).Click();
                    break;
                //RESET APP STATE link
                case 4:
                    driver.FindElement(resetAppLink).Click();
                    break;
                //No link to click
                default:
                    driver.FindElement(hamburgerMenu).Click();
                    break;
            }
        }
    }
}