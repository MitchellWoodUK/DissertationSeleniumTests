﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace DissertationProject.Tests
{
    [TestFixture]
    public class RegisterTests
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
        public void CanRegisterNewAccount()
        {
            //Make the window fullscreen
            driver.Manage().Window.Maximize();
            // Navigate to the register page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Register");
            // Fill in the registration form inputs
            IWebElement fnameInput = driver.FindElement(By.Id("Input_Fname"));
            fnameInput.SendKeys("John");
            IWebElement snameInput = driver.FindElement(By.Id("Input_Sname"));
            snameInput.SendKeys("Doe");
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");

            IWebElement confirmPasswordInput = driver.FindElement(By.Id("Input_ConfirmPassword"));
            confirmPasswordInput.SendKeys("Pass123!");
            // Submit the form

            IWebElement register = driver.FindElement(By.Id("registerSubmit"));
            register.Click();

            // Verify that the registration was successful
            //Assert
            Assert.IsTrue(driver.Url.Contains("https://localhost:7170"));
        }


        [Test]
        public void RejectIncorrectData()
        {
            //Make the window fullscreen
            driver.Manage().Window.Maximize();
            // Navigate to the register page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Register");

            // Fill in the registration form inputs with incorrect data
            IWebElement fnameInput = driver.FindElement(By.Id("Input_Fname"));
            fnameInput.SendKeys("John");

            IWebElement snameInput = driver.FindElement(By.Id("Input_Sname"));
            snameInput.SendKeys("Doe");

            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("invalidemail");  // Invalid email format

            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");

            IWebElement confirmPasswordInput = driver.FindElement(By.Id("Input_ConfirmPassword"));
            confirmPasswordInput.SendKeys("Pass456!");  // Password mismatch

            // Submit the form
            IWebElement register = driver.FindElement(By.Id("registerSubmit"));
            register.Click();

            // Wait for the error message to be displayed
            IWebElement error = driver.FindElement(By.Id("Input_Email-error"));


            // Verify that the error message is displayed
            Assert.IsTrue(error.Displayed);
        }

    }
}
