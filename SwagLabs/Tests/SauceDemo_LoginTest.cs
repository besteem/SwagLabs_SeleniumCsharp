using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SwagLabs.PageObjects;

namespace SwagLabs.Tests
{
    public class SauceDemo_LoginTest
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void BrowserInitialization()
        {
            driver = new ChromeDriver("C:/Users/esteen/testAutomation/webDriver");
            driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void NavigateToLoginPage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test, Ignore("reason")]
        public void Practice()
        {
            Assert.IsTrue(true);
        }

        [Test, Description("Successful Login")]
        [TestCase("standard_user")]
        [TestCase("problem_user")]
        [TestCase("performance_glitch_user")]
        public void ShouldBeAbleToLoginSuccessfully(string username)
        {
            var login = new SauceDemo_LoginPage(driver);
            var variable = new Variables();
            login.LoginToSauceDemo(username, variable.validPassword);
            var homepage = new SauceDemo_HomePage(driver);
            Assert.IsTrue(homepage.IsNavigatedToHomePage());
        }

        [Test, Description("No password provided")]
        public void ShouldNotBeAbleToLoginWhenPasswordIsBlank()
        {
            var login = new SauceDemo_LoginPage(driver);
            var variable = new Variables();
            login.EnterUsername(variable.validUsername);
            login.ClickLoginButton();
            Assert.AreEqual(variable.passwordRequiredErrorMessage, login.GetLoginErrorMessage());
        }

        [Test, Description("No username provided")]
        public void ShouldNotBeAbleToLoginWhenUsernameIsBlank()
        {
            var login = new SauceDemo_LoginPage(driver);
            var variable = new Variables();
            login.EnterPassword(variable.validPassword);
            login.ClickLoginButton();
            Assert.AreEqual(variable.usernameRequiredErrorMessage, login.GetLoginErrorMessage());
        }

        [Test, Description("No username and password provided")]
        public void ShouldNotBeAbleToLoginWhenCredentialsAreBlank()
        {
            var login = new SauceDemo_LoginPage(driver);
            var variable = new Variables();
            login.ClickLoginButton();
            Assert.AreEqual(variable.usernameRequiredErrorMessage, login.GetLoginErrorMessage());
        }

        [Test, Description("Invalid username is provided")]
        public void ShouldNotBeAbleToLoginForInvalidUsername()
        {
            var login = new SauceDemo_LoginPage(driver);
            var variable = new Variables();
            login.LoginToSauceDemo(variable.invalidCredential, variable.validPassword);
            Assert.AreEqual(variable.invalidCredentialErrorMessage, login.GetLoginErrorMessage());
        }

        [Test, Description("Invalid password is provided")]
        public void ShouldNotBeAbleToLoginFOrInvalidPassword()
        {
            var login = new SauceDemo_LoginPage(driver);
            var variable = new Variables();
            login.LoginToSauceDemo(variable.validUsername, variable.invalidCredential);
            Assert.AreEqual(variable.invalidCredentialErrorMessage, login.GetLoginErrorMessage());
        }

        [Test, Description("Locked Out user credential is provided")]
        public void LockedOutUserShouldNotBeABleToLogin()
        {
            var login = new SauceDemo_LoginPage(driver);
            var variable = new Variables();
            login.LoginToSauceDemo(variable.lockedOutUser, variable.validPassword);
            Assert.AreEqual(variable.lockedOutUserErrorMessage, login.GetLoginErrorMessage());
        }

        [TearDown]
        public void LogoutFromTheSite()
        {
            var homepage = new SauceDemo_HomePage(driver);
            homepage.LogoutFromSite();
            var login = new SauceDemo_LoginPage(driver);
            Assert.IsTrue(login.IsNavigatedToLoginPage());
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}