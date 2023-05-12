using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace DissertationProject.Tests
{
    [TestFixture]
    public class SettingsTests
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
        public void editAllUserData()
        {
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

            // Go to the settings page#
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 3; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement settings = driver.FindElement(By.Name("settingsbtn"));
            settings.Click();
            //Change the users details
            IWebElement fname = driver.FindElement(By.Id("fname"));
            fname.SendKeys("Joe");
            IWebElement sname = driver.FindElement(By.Id("sname"));
            sname.SendKeys("Smith");
            IWebElement jobName = driver.FindElement(By.Id("jobName"));
            jobName.SendKeys("Asda Worker");
            IWebElement income = driver.FindElement(By.Id("income"));
            income.SendKeys("2000");
            //Click submit
            IWebElement submit = driver.FindElement(By.Id("submitbtn"));
            submit.Click();

            //Assert

        }

        [Test]
        public void editSingleUserData()
        {
            //Arrange
           

            //Act
            //Go to the login page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login"); 
            // Fill in the login form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");
            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Go to the settings page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 3; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement settings = driver.FindElement(By.Name("settingsbtn"));
            settings.Click();

            IWebElement jobName = driver.FindElement(By.Id("jobName"));
            jobName.SendKeys("Sainsburys Worker");
            //Click submit
            IWebElement submit = driver.FindElement(By.Id("submitbtn"));
            submit.Click();

            //Assert


        }

        [Test]
        public void CreateFamily()
        {
            //Arrange
            bool isDisplayed = false;

            //Act
            //Go to the login page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");
            // Fill in the login form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");
            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Go to the settings page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 1; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement settings = driver.FindElement(By.Name("settingsbtn"));
            settings.Click();

            //Create a new family
            IWebElement scroll2 = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 3; i++)
            {
                scroll2.SendKeys(Keys.PageDown);
            }
            IWebElement familyName = driver.FindElement(By.Id("name"));
            familyName.SendKeys("Test");
            IWebElement familyPIN = driver.FindElement(By.Id("pin"));
            familyPIN.SendKeys("0000");
            IWebElement submit = driver.FindElement(By.Id("submitCreate"));
            submit.Click();
            IWebElement alert = driver.FindElement(By.ClassName("successMessage"));
            isDisplayed = alert.Displayed;

            //Assert
            Assert.IsTrue(isDisplayed);
        }

        [Test]
        public void CreateFamilyIncorrect()
        {
            //Arrange
            bool isDisplayed = false;

            //Act
            //Go to the login page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");
            // Fill in the login form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");
            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Go to the settings page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 1; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement settings = driver.FindElement(By.Name("settingsbtn"));
            settings.Click();

            //Create a new family
            IWebElement scroll2 = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 3; i++)
            {
                scroll2.SendKeys(Keys.PageDown);
            }
            IWebElement familyName = driver.FindElement(By.Id("name"));
            familyName.SendKeys("Test");
            IWebElement submit = driver.FindElement(By.Id("submitCreate"));
            submit.Click();
            IWebElement alert = driver.FindElement(By.ClassName("successMessage"));
            isDisplayed = alert.Displayed;

            //Assert
            Assert.IsTrue(isDisplayed);
        }

        [Test]
        public void UnlinkFromFamily()
        {
            //Arrange
            bool isDisplayed = false;

            //Act
            //Go to the login page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");
            // Fill in the login form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");
            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Go to the settings page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 1; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement settings = driver.FindElement(By.Name("settingsbtn"));
            settings.Click();

            //Create a new family
            IWebElement scroll2 = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 3; i++)
            {
                scroll2.SendKeys(Keys.PageDown);
            }
            //Unlink from family
            IWebElement name = driver.FindElement(By.Id("name"));
            name.SendKeys("Test");
            IWebElement submit = driver.FindElement(By.Id("unlinkbtn"));
            submit.Click();

            IWebElement alert = driver.FindElement(By.ClassName("successMessage"));
            isDisplayed = alert.Displayed;

            //Assert
            Assert.IsTrue(isDisplayed);
        }

        [Test]
        public void JoinFamilyCorrect()
        {
            //Arrange
            bool isDisplayed = false;

            //Act
            //Go to the login page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");
            // Fill in the login form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");
            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Go to the settings page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 1; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement settings = driver.FindElement(By.Name("settingsbtn"));
            settings.Click();

            //Create a new family
            IWebElement scroll2 = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 3; i++)
            {
                scroll2.SendKeys(Keys.PageDown);
            }
            IWebElement familyName = driver.FindElement(By.Id("joinname"));
            familyName.SendKeys("Test");
            IWebElement familyPIN = driver.FindElement(By.Id("joinpin"));
            familyPIN.SendKeys("0000");
            IWebElement submit = driver.FindElement(By.Id("submitJoin"));
            submit.Click();
            IWebElement alert = driver.FindElement(By.ClassName("successMessage"));
            isDisplayed = alert.Displayed;

            //Assert
            Assert.IsTrue(isDisplayed);
        }

        [Test]
        public void JoinFamilyIncorrect()
        {
            //Arrange
            bool isDisplayed = false;

            //Act
            //Go to the login page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");
            // Fill in the login form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");
            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Go to the settings page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 1; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement settings = driver.FindElement(By.Name("settingsbtn"));
            settings.Click();

            //Create a new family
            IWebElement scroll2 = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 3; i++)
            {
                scroll2.SendKeys(Keys.PageDown);
            }
            IWebElement familyName = driver.FindElement(By.Id("managebtn"));
            familyName.SendKeys("Test");
            IWebElement familyPIN = driver.FindElement(By.Id("joinpin"));
            familyPIN.SendKeys("1111");
            IWebElement submit = driver.FindElement(By.Id("submitJoin"));
            submit.Click();
            IWebElement alert = driver.FindElement(By.ClassName("successMessage"));
            isDisplayed = alert.Displayed;

            //Assert
            Assert.IsTrue(isDisplayed);
        }

        [Test]
        public void ManageFamilyMembers()
        {
            //Arrange
            bool isDisplayed = false;

            //Act
            //Go to the login page
            driver.Navigate().GoToUrl("https://localhost:7170/Identity/Account/Login");
            // Fill in the login form inputs
            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("johndoe@example.com");
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Pass123!");
            // Submit the form
            IWebElement register = driver.FindElement(By.Id("login-submit"));
            register.Click();

            // Go to the settings page
            IWebElement scroll = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 1; i++)
            {
                scroll.SendKeys(Keys.PageDown);
            }
            IWebElement settings = driver.FindElement(By.Name("settingsbtn"));
            settings.Click();

            //Create a new family
            IWebElement scroll2 = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < 3; i++)
            {
                scroll2.SendKeys(Keys.PageDown);
            }
            IWebElement managebtn = driver.FindElement(By.Id("managebtn"));
            managebtn.Click();
            IWebElement addrolebtn = driver.FindElement(By.Id("addrolebtn"));
            addrolebtn.Click();
            IWebElement kidselect = driver.FindElement(By.Id("family_kid"));
            kidselect.Click();
            IWebElement submitbtn = driver.FindElement(By.Id("submitRole"));
            submitbtn.Click();


            IWebElement alert = driver.FindElement(By.ClassName("successMessage"));
            isDisplayed = alert.Displayed;

            //Assert
            Assert.IsTrue(isDisplayed);
        }
    }
}
