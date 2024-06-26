using MarsTest.Pages;
using MarsTest.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsTest.Tests
{
    internal class LanguageTest : CommonDriver
    {    
        
        LoginPage loginPage= new LoginPage();
        LanguagePage languagePage = new LanguagePage();


        [SetUp]
        public void Setup()
        {
            //Create WebDrive
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //Navigate to URL
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //Navigate to login page
            loginPage.loginPage(driver);          

        }

        [TearDown]
        public void TearDown()
        {
            //Dispose Webdriver
            driver.Quit();
        }


        [Test, Order(1)]
        public void SuccessfullyNavigateProfilePageWithSelectedLanguageTab()
        {
            Assert.Pass();
            //Assertion to the profile page navigation
        }

        [Test, Order(2)]
        [TestCase("English", "Fluent")]
        public void SuccessfullyAddNewLanguage(string language, string level) 
        {

            languagePage.SuccessfullyAddnewLanguage(driver, language, level); 
        }

        [Test, Order(3)]
        public void SuccessfullyEditExistingLanguageAndLanguageLevel()
        {
            languagePage.SuccessfullyEditExistingLanguageAndLanguageLevel(driver);
        }

        [Test, Order(4)]
        public void SuccsfullyEditOnlyExistingLanguageToANewLanguageWithoutEditLanguageLevel()
        {
            languagePage.SuccsfullyEditOnlyExistingLanguageToANewLanguageWithoutEditLanguageLevel(driver);
        }
        /*
        [Test, Order(5)]
        public void SuccsfullyEditLanguageLevelWithoutEditLanguage()
        {
            languagePage.SuccsfullyEditLanguageLevelWithoutEditLanguage(driver);
        }
        */

        [Test, Order(6)]
        public void CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel()
        {
            languagePage.CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(driver);

        }


        [Test, Order(7)]
        public void CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage()
        {
            languagePage.CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(driver);
        }

    }
}
