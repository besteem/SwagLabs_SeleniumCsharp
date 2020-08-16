using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;

namespace SwagLabs.PageObjects
{
    public class SauceDemo_LoginPage
    {
        public IWebDriver driver;

        //locators
        public By usernameTextField = By.XPath("//*[@id='user-name']");
        public By passwordTextField = By.XPath("//*[@id='password']");
        public By loginButton = By.XPath("//*[@id='login-button']");
        public By loginBox = By.XPath("//*[@id='login_button_container']");
        public By loginErrorMessage = By.XPath("//*[contains(@data-test, 'error')]");

        public SauceDemo_LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Description: Enter username in username textfield
        public void EnterUsername(string username)
        {
            driver.FindElement(usernameTextField).SendKeys(username);
        }

        //Description: Enter password in password textfield
        public void EnterPassword(string password)
        {
            driver.FindElement(passwordTextField).SendKeys(password);
        }

        //Description: Click LOGIN button
        public void ClickLoginButton()
        {
            driver.FindElement(loginButton).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        //Description: Login to SauceDemo site
        public void LoginToSauceDemo(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        /*Description: Verify display of login box
        return true - login box is displayed
        return false - login box is not displayed
        */
        public bool IsNavigatedToLoginPage()
        {
            return driver.FindElement(loginBox).Displayed;
        }

        //Description: Get unsuccessfull login error message
        public string GetLoginErrorMessage()
        {
            return driver.FindElement(loginErrorMessage).Text;
        }
    }
}