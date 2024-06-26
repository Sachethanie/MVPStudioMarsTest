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

    internal class SkillTest : CommonDriver
    {

        LoginPage loginPage = new LoginPage();
        SkillPage skillPage = new SkillPage();


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

            IWebElement skillTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillTab.Click();

        }

        [TearDown]
        public void TearDown()
        {
            //Dispose Webdriver

            driver.Quit();

        }



        [Test, Order(1)]
        public void SuccessfullyAddNewSkill()
        {
            skillPage.SuccessfullyAddNewSkill(driver);
        }

        [Test, Order(2)]
        public void SuccessfullyEditExistingSkillAndSkillLevel()
        {
            skillPage.SuccessfullyEditExistingSkillAndSkillLevel(driver);
        }

        [Test, Order(3)]
        public void SuccsfullyEditOnlyExistingSkillToANewSkillWithoutEditSkillLevel()
        {
            skillPage.SuccsfullyEditOnlyExistingSkillToANewSkillWithoutEditSkillLevel(driver);
        }

        [Test, Order(4)]
        public void SuccsfullyEditSkillLevelWithoutEditSkill()
        {
            skillPage.SuccsfullyEditSkillLevelWithoutEditSkill(driver);
        }


        [Test, Order(5)]
        public void CannotBeAbleToAddnewSkillWithoutAddingSkillLevel()
        {
            skillPage.CannotBeAbleToAddnewSkillWithoutAddingSkillLevel(driver);
        }


        [Test, Order(6)]
        public void CannotBeAbleToAddExistingSkillAndSkillLevelAsANewSkill()
        {
            skillPage.CannotBeAbleToAddExistingSkillAndSkillLevelAsANewSkill(driver);
        }
    }

}
