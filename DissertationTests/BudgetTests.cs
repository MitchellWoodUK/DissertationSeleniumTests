using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace DissertationProject.Tests
{
    [TestFixture]
    public class BudgetTests
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
        public void NavigateToBudget()
        {
            //Make the window fullscreen
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

            // Go to the budget page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 2; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            //Navigate to the budget page throught the navigation bar.
            IWebElement navbtn = driver.FindElement(By.Id("burgerbtn"));
            navbtn.Click();
            Thread.Sleep(1000);
            IWebElement budgetbtn = driver.FindElement(By.Id("budgetNav"));
            budgetbtn.Click();


            //Assert
            Assert.IsTrue(driver.Url.Contains("Budget/Manage"));
        }

        [Test]
        public void SetBudget()
        {
            //Make the window fullscreen
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

            // Go to the budget page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 2; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            //Navigate to the budget page throught the navigation bar.
            IWebElement navbtn = driver.FindElement(By.Id("burgerbtn"));
            navbtn.Click();
            Thread.Sleep(1000);
            IWebElement budgetbtn = driver.FindElement(By.Id("budgetNav"));
            budgetbtn.Click();

            //Set budget
            IWebElement budgetInput = driver.FindElement(By.Id("budget"));
            budgetInput.SendKeys("1000");
            IWebElement submit = driver.FindElement(By.Id("setbudget"));
            submit.Click();

            //Assert
            Assert.IsTrue(driver.Url.Contains("Budget/Manage"));
        }

        [Test]
        public void UpdateBudget()
        {
            //Make the window fullscreen
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

            // Go to the budget page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 2; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            //Navigate to the budget page throught the navigation bar.
            IWebElement navbtn = driver.FindElement(By.Id("burgerbtn"));
            navbtn.Click();
            Thread.Sleep(1000);
            IWebElement budgetbtn = driver.FindElement(By.Id("budgetNav"));
            budgetbtn.Click();

            //Set budget
            IWebElement budgetInput = driver.FindElement(By.Id("budget"));
            budgetInput.SendKeys("6000");
            IWebElement submit = driver.FindElement(By.Id("updatebudget"));
            submit.Click();

            //Assert
            Assert.IsTrue(driver.Url.Contains("Budget/Manage"));
        }

       
    }
}
