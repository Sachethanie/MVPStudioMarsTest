using MarsTest.Utils;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsTest.Pages
{
    public class SkillPage
    {
        public void SuccessfullyAddNewSkill(IWebDriver driver)
        {          

            string skillToBeAdd = "QA";
            string skillLevelToBeAdd = "Expert";  

            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            //Assertion
            Thread.Sleep(1000);
            WaitHelper.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input", 30);

            IWebElement addSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            IWebElement addSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            SelectElement dropdown = new SelectElement(addSkillLevel);

            addSkill.SendKeys(skillToBeAdd);
            dropdown.SelectByText(skillLevelToBeAdd);
            
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(skillLevelToBeAdd));

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();
            WaitHelper.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]", 30);

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));
            //IWebElement toastMessageElement1 = driver.FindElement(By.ClassName("ns-box"));


            string expectedMessage = $"{skillToBeAdd} has been added to your skills";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));


            // visible added value

            //get the raw
            var table = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));
            IList<IWebElement> tableBody = table.FindElements(By.TagName("tbody"));
            IWebElement lastTableBody = tableBody.Last().FindElement(By.TagName("tr"));
            IList<IWebElement> cells = lastTableBody.FindElements(By.TagName("td"));

            String skillAfterAdd = cells[0].Text;
            String skillLevelAfterAdd = cells[1].Text;

            //Assertion
            Assert.That(skillAfterAdd == skillToBeAdd, "skill does not match");
            Assert.That(skillLevelAfterAdd == skillLevelToBeAdd, "skill level does not match");
        }

        public void CannotBeAbleToAddnewSkillWithoutAddingSkillLevel(IWebDriver driver)
        {
            string skillToBeAdd = "Python";

            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            //Assertion

            WaitHelper.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input", 30);

            IWebElement addSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));

            addSkill.SendKeys(skillToBeAdd);

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();
           

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));
            IWebElement toastMessageElement1 = driver.FindElement(By.ClassName("ns-box"));


            string expectedMessage = "Please enter skill and experience level";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }


        public void CannotBeAbleToAddExistingSkillAndSkillLevelAsANewSkill(IWebDriver driver)
        {
            string skillToBeAdd = "QA";
            string skillLevelToBeAdd = "Expert";


            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            //Assertion

            WaitHelper.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input", 30);

            IWebElement addSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            IWebElement addSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            SelectElement dropdown = new SelectElement(addSkillLevel);

            addSkill.SendKeys(skillToBeAdd);
            dropdown.SelectByText(skillLevelToBeAdd);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(skillLevelToBeAdd));

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();            

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));          

            string expectedMessage = "This skill is already exist in your skill list.";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));


            // visible added value

            //get the raw
            var table = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));
            IList<IWebElement> tableBody = table.FindElements(By.TagName("tbody"));
            IWebElement lastTableBody = tableBody.Last().FindElement(By.TagName("tr"));
            IList<IWebElement> cells = lastTableBody.FindElements(By.TagName("td"));

            String skillAfterAdd = cells[0].Text;
            String skillLevelAfterAdd = cells[1].Text;

            //Assertion
            Assert.That(skillAfterAdd == skillToBeAdd, "skill does not match");
            Assert.That(skillLevelAfterAdd == skillLevelToBeAdd, "skill level does not match");

        }

        public void SuccessfullyEditExistingSkillAndSkillLevel(IWebDriver driver)
        {
            string skillToBeEdit = "Java";
            string skillLevelToBeEdit = "Beginner";           

            IWebElement editPencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            editPencilIcon.Click();


            IWebElement addSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            addSkill.Clear();
            addSkill.SendKeys(skillToBeEdit);

            IWebElement addSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            SelectElement dropdown = new SelectElement(addSkillLevel);
            addSkillLevel.Click();

            addSkillLevel.SendKeys(skillLevelToBeEdit);
            addSkillLevel.SendKeys(Keys.Enter);

            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));

            string expectedMessage = $"{skillToBeEdit} has been updated to your skills";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));


        }

        public void SuccsfullyEditOnlyExistingSkillToANewSkillWithoutEditSkillLevel(IWebDriver driver)
        {
            string skillToBeEdit = "C#";

            IWebElement editPencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            editPencilIcon.Click();

            IWebElement addSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            addSkill.Clear();
            addSkill.SendKeys(skillToBeEdit);

            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            // WaitHelper.waitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]", 30);
            ////*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));

            string expectedMessage = $"{skillToBeEdit} has been updated to your skills";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));

        }

        public void SuccsfullyEditSkillLevelWithoutEditSkill(IWebDriver driver)
        {           
            string skillLevelToBeEdit = "Intermediate";
           
            IWebElement editPencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            editPencilIcon.Click();
            
            IWebElement addSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));
            SelectElement dropdown = new SelectElement(addSkillLevel);
            addSkillLevel.Click();

            addSkillLevel.SendKeys(skillLevelToBeEdit);
            addSkillLevel.SendKeys(Keys.Enter);


            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            WaitHelper.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 30);



        }

        public void deleteExistingSkill(IWebDriver driver)
        {


        }

    }
}
