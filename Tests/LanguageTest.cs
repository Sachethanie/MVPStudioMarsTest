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
    public class LanguageTest : CommonDriver
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
            string expectedUrl = "http://localhost:5000/Account/Profile#";
            driver.Navigate().GoToUrl(expectedUrl);

            string actualUrl = driver.Url;
            Assert.That(actualUrl, Is.EqualTo(expectedUrl), "The URL is not as expected.");

        }

        [Test, Order(2)]
        [TestCase("English", "Fluent")]
        [TestCase("Arabic", "Fluent")]
        public void SuccessfullyAddNewLanguage(string language, string level) 
        {
            languagePage.SuccessfullyAddNewLanguage(driver, language, level); 
        }

        [Test, Order(3)]
        [TestCase("Sinhala", "Coversational")]
        public void SuccessfullyEditExistingLanguageAndLanguageLevel(string language, string level)
        {
            languagePage.SuccessfullyEditExistingLanguageAndLanguageLevel(driver, language, level);
        }

        [Test, Order(4)]
        [TestCase("Swedish")]
        public void SuccsfullyEditOnlyExistingLanguageToANewLanguageWithoutEditLanguageLevel(string language)
        {
            languagePage.SuccsfullyEditOnlyExistingLanguageToANewLanguageWithoutEditLanguageLevel(driver, language);
        }
        
        [Test, Order(5)]
        [TestCase("Basic")]
        public void SuccsfullyEditLanguageLevelWithoutEditLanguage(string level)
        {
            languagePage.SuccsfullyEditLanguageLevelWithoutEditLanguage(driver, level);
        }
        

        [Test, Order(6)]
        [TestCase("Spanish")]
        public void CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(string language)
        {
            languagePage.CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(driver , language);

        }

        [Test, Order(7)]
        [TestCase("Swedish", "Basic")]
        public void CannotBeAbleToAddExistingLanguageAndLanguageLevelAsANewLanguage(string language, string level)
        {
            languagePage.CannotBeAbleToAddExistingLanguageAndLanguageLevelAsANewLanguage(driver, language, level);

        }


        [Test, Order(8)]
        [TestCase("English", "Fluent")]
        public void CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(string language, string level)
        {
            languagePage.CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(driver, language, level);
        }


        [Test, Order(9)]       
        public void SuccessfullydeleteExistingLanguage()
        {
            languagePage.SuccessfullydeleteExistingLanguage(driver);
        }
    }
}
