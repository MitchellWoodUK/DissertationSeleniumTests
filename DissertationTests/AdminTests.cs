using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace DissertationProject.Tests
{
    [TestFixture]
    public class AdminTests
    {
        //Has to be created in the main program so that it can be accessed in different methods.
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions ops = new ChromeOptions();
            //Tests run in the background.
            //ops.AddArgument("--headless");
            driver = new ChromeDriver(@"\Drivers\chromedriver_win32", ops);
        }

        [Test]
        public void AdminRemoveFamily()
        {
            // Navigate to the register page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");
            // Fill in the registration form inputs

            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("admin@moneytree.com");

            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Admin123!");

            // Submit the form

            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            IWebElement adminDropdown = driver.FindElement(By.Id("admin"));
            adminDropdown.Click();

            System.Threading.Thread.Sleep(1000);
            IWebElement manageFamilyLink = driver.FindElement(By.Id("manageFamily"));

            // click the "Manage Familys" link
            manageFamilyLink.Click();

            // locate the Remove button and click it
            IWebElement removeButton = driver.FindElement(By.Id("removeFamily"));
            removeButton.Click();

            // switch to the alert, accept it, and then switch back to the main window
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();


            // Verify that the registration was successful
            //Assert
            Assert.IsTrue(driver.Url.Contains("https://localhost:7170/"));
        }


     

    }
}
