using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace DissertationProject.Tests
{
    [TestFixture]
    public class BillsTests
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
        public void NavigateToBills()
        {
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            // Navigate to the register page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");

            // Fill in the registration form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");

            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Wait for the registration confirmation page to load

            // Go to the transaction page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 4; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement bills = driver.FindElement(By.Id("billid"));
            bills.Click();


            //Assert
            Assert.IsTrue(driver.Url.Contains("Bills/ViewAll"));
        }

        [Test]
        public void CreateBillCorrect()
        {
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            // Navigate to the register page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");

            // Fill in the registration form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");

            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Go to the transaction page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 5; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement bills = driver.FindElement(By.Id("billid"));
            bills.Click();
            IWebElement create = driver.FindElement(By.Id("newbillbtn"));
            create.Click();
            //Enter the correct details for a transaction
            IWebElement name = driver.FindElement(By.Id("name"));
            name.SendKeys("Electric");
            IWebElement description = driver.FindElement(By.Id("description"));
            description.SendKeys("Monthly Bill");
            IWebElement amount = driver.FindElement(By.Id("amount"));
            amount.SendKeys("140");
            IWebElement type = driver.FindElement(By.Id("billType"));
            type.SendKeys("Electric");
            IWebElement due = driver.FindElement(By.Id("dateDue"));
            due.SendKeys("1");
            IWebElement submit = driver.FindElement(By.Id("submitbtn"));
            submit.Click();


            //Assert
            Assert.IsTrue(driver.Url.Contains("Bills/ViewAll"));
        }

        [Test]
        public void CreateBillMissingValue()
        {
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            // Navigate to the register page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");

            // Fill in the registration form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");

            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Go to the transaction page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 5; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement bills = driver.FindElement(By.Id("billid"));
            bills.Click();
            IWebElement create = driver.FindElement(By.Id("newbillbtn"));
            create.Click();
            //Enter the correct details for a transaction
            
            IWebElement description = driver.FindElement(By.Id("description"));
            description.SendKeys("Monthly Bill");
            IWebElement amount = driver.FindElement(By.Id("amount"));
            amount.SendKeys("140");
            IWebElement type = driver.FindElement(By.Id("billType"));
            type.SendKeys("Electric");
            IWebElement due = driver.FindElement(By.Id("dateDue"));
            due.SendKeys("1");
            IWebElement submit = driver.FindElement(By.Id("submitbtn"));
            submit.Click();


            //Assert
            Assert.IsTrue(driver.Url.Contains("Bills/ViewAll"));
        }


        [Test]
        public void DeleteBill()
        {
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            // Navigate to the register page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");

            // Fill in the registration form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");

            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Go to the transaction page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 2; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement bills = driver.FindElement(By.Id("billid"));
            bills.Click();
            IWebElement delete = driver.FindElement(By.Id("deletebtn"));
            delete.Click();
            // switch to the alert, accept it, and then switch back to the main window
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            //Assert
            Assert.IsTrue(driver.Url.Contains("Transaction/ViewAll"));
        }

        [Test]
        public void TestBackToBills()
        {
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            // Navigate to the register page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");

            // Fill in the registration form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");

            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Go to the transaction page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 5; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement bills = driver.FindElement(By.Id("billid"));
            bills.Click();
            IWebElement create = driver.FindElement(By.Id("newbillbtn"));
            create.Click();
            //Click the back button
            IWebElement back = driver.FindElement(By.Id("backbtn"));
            back.Click();

            //Assert
            Assert.IsTrue(driver.Url.Contains("Bills/ViewAll"));
        }
    }
}
