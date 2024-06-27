using MarsTest.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsTest.Pages
{
    public class LanguagePage
    {
        private const string xPathAddNewButton = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div";
        private const string xPathaddLanguage = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input";
        private const string xPathaddLanguageLevel = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select";
        private const string xPathAddButton = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]";
        private const string xPathEditPencilIcon = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]";
        private const string xPathEditLanguage = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input";
        private const string xPathEditLanguageLevel = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select";
        private const string xPathUpdateButton = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]";
        private const string xPathDeletCrossIcon = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]";

        public void SuccessfullyAddNewLanguage(IWebDriver driver, string languageToBeAdd, string languageLevelToBeAdd)
        {

            IWebElement addNewButton = driver.FindElement(By.XPath(xPathAddNewButton));
            addNewButton.Click();
          
            WaitHelper.WaitToBeVisible(driver, "XPath", xPathaddLanguage, 30);

            IWebElement addLanguage = driver.FindElement(By.XPath(xPathaddLanguage));
            IWebElement addLanguageLevel = driver.FindElement(By.XPath(xPathaddLanguageLevel));
            SelectElement dropdown = new SelectElement(addLanguageLevel);

            addLanguage.SendKeys(languageToBeAdd);
            dropdown.SelectByText(languageLevelToBeAdd);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(languageLevelToBeAdd));

            IWebElement addButton = driver.FindElement(By.XPath(xPathAddButton));
            addButton.Click();

            //Assertion 
            string expectedMessage = $"{languageToBeAdd} has been added to your languages";
            AssertionPopupMessage(driver, expectedMessage);

            // visible added value

            //get the raw
            var table = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
            IList<IWebElement> tableBody = table.FindElements(By.TagName("tbody"));
            IWebElement lastTableBody = tableBody.Last().FindElement(By.TagName("tr"));
            IList<IWebElement> cells = lastTableBody.FindElements(By.TagName("td"));

            String languageAfterAdd = cells[0].Text;
            String languageLevelAfterAdd = cells[1].Text;

            //Assertion
            Assert.That(languageAfterAdd == languageToBeAdd, "Language does not match");
            Assert.That(languageLevelAfterAdd == languageLevelToBeAdd, "Language level does not match");

        }

        private void AssertionPopupMessage(IWebDriver driver, string expectedMessage)
        {
            WaitHelper.WaitToBeVisible(driver, "ClassName", "ns-box", 30);
            IWebElement toastMessageElement = driver.FindElement(By.ClassName("ns-box"));           
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        public void CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(IWebDriver driver, string languageToBeAdd)

        {
            IWebElement addNewButton = driver.FindElement(By.XPath(xPathAddNewButton));
            addNewButton.Click();
            //Assertion

            WaitHelper.WaitToBeClickable(driver, "XPath", xPathaddLanguage, 30);

            IWebElement addLanguage = driver.FindElement(By.XPath(xPathaddLanguage));
            
            addLanguage.SendKeys(languageToBeAdd);

            IWebElement addButton = driver.FindElement(By.XPath(xPathAddButton));
            addButton.Click();
            //thred sleep 

            //Assertion
            string expectedMessage = "Please enter language and level";
            AssertionPopupMessage(driver, expectedMessage);           

        }

        public void CannotBeAbleToAddExistingLanguageAndLanguageLevelAsANewLanguage(IWebDriver driver, string languageToBeAdd, string languageLevelToBeAdd)

        {   
            IWebElement addNewButton = driver.FindElement(By.XPath(xPathAddNewButton));
            //Assertion

            WaitHelper.WaitToBeClickable(driver, "XPath", xPathaddLanguage, 30);

            IWebElement addLanguage = driver.FindElement(By.XPath(xPathaddLanguage));
            IWebElement addLanguageLevel = driver.FindElement(By.XPath(xPathaddLanguageLevel));
            SelectElement dropdown = new SelectElement(addLanguageLevel);

            addLanguage.SendKeys(languageToBeAdd);
            dropdown.SelectByText(languageLevelToBeAdd);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(languageLevelToBeAdd));

            IWebElement addButton = driver.FindElement(By.XPath(xPathAddButton));
            addButton.Click();

            //Assertion
            string expectedMessage = "This language is already exist in your language list";
            AssertionPopupMessage(driver, expectedMessage);
        }
        /*
        private void GetAddedLanguages(IWebDriver driver)
        {
            List<string> languages = new List<string>();
            IList<IWebElement> languageElements = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));

            foreach (IWebElement element in languageElements)
            {
                languages.Add(element.Text);
            }
            //return languages;
        }
        */

        public void SuccessfullyEditExistingLanguageAndLanguageLevel(IWebDriver driver, string languageToBeEdit, string languageLevelToBeEdit2)

        {
            IWebElement editPencilIcon = driver.FindElement(By.XPath(xPathEditPencilIcon));
            editPencilIcon.Click();


            IWebElement editLanguage = driver.FindElement(By.XPath(xPathEditLanguage));
            editLanguage.Clear();
            editLanguage.SendKeys(languageToBeEdit);

            IWebElement editLanguageLevel = driver.FindElement(By.XPath(xPathEditLanguageLevel));
            SelectElement dropdown = new SelectElement(editLanguageLevel);
            editLanguageLevel.Click();

            editLanguageLevel.SendKeys(languageLevelToBeEdit2);
            editLanguageLevel.SendKeys(Keys.Enter);


            IWebElement updateButton = driver.FindElement(By.XPath(xPathUpdateButton));
            updateButton.Click();

            //Assertion
            string expectedMessage = $"{languageToBeEdit} has been updated to your languages";
            AssertionPopupMessage(driver, expectedMessage);

        }

        public void SuccsfullyEditOnlyExistingLanguageToANewLanguageWithoutEditLanguageLevel(IWebDriver driver, string languageToBeEdit) 

        {
            IWebElement editPencilIcon = driver.FindElement(By.XPath(xPathEditPencilIcon));
            editPencilIcon.Click();

            IWebElement editLanguage = driver.FindElement(By.XPath(xPathEditLanguage));
            editLanguage.Clear();
            editLanguage.SendKeys(languageToBeEdit);

            IWebElement updateButton = driver.FindElement(By.XPath(xPathUpdateButton));
            updateButton.Click();
        
            string expectedMessage = $"{languageToBeEdit} has been updated to your languages";
            AssertionPopupMessage(driver, expectedMessage);

        }
        
        public void SuccsfullyEditLanguageLevelWithoutEditLanguage(IWebDriver driver, string languageLevelToBeEdit)

        {   
            IWebElement editPencilIcon = driver.FindElement(By.XPath(xPathEditPencilIcon));
            editPencilIcon.Click();

            IWebElement editLanguageLevel = driver.FindElement(By.XPath(xPathEditLanguageLevel));
            SelectElement dropdown = new SelectElement(editLanguageLevel);
            editLanguageLevel.Click();

            editLanguageLevel.SendKeys(languageLevelToBeEdit);
            editLanguageLevel.SendKeys(Keys.Enter);


            IWebElement updateButton = driver.FindElement(By.XPath(xPathUpdateButton));
            updateButton.Click();
            WaitHelper.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]", 30);

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));
            //IWebElement toastMessageElement1 = driver.FindElement(By.ClassName("ns-box"));


            string expectedMessage = "Sinhala has been updated to your languages";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));

        }
        

        public void CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(IWebDriver driver, string languageToBeEdit, string languageLevelToBeEdit2)

        {
            


            IWebElement editLanguage = driver.FindElement(By.XPath(xPathEditLanguage));
            editLanguage.Clear();
            editLanguage.SendKeys(languageToBeEdit);

            IWebElement editLanguageLevel = driver.FindElement(By.XPath(xPathEditLanguageLevel));
            SelectElement dropdown = new SelectElement(editLanguageLevel);
            editLanguageLevel.Click();

            editLanguageLevel.SendKeys(languageLevelToBeEdit2);
            editLanguageLevel.SendKeys(Keys.Enter);

            IWebElement updateButton = driver.FindElement(By.XPath(xPathUpdateButton));
            updateButton.Click();

            string expectedMessage = "This language is already added to your language list.";
            AssertionPopupMessage(driver, expectedMessage);
        }


        public void SuccessfullydeleteExistingLanguage(IWebDriver driver) 
        {
            IWebElement deletCrossIcon = driver.FindElement(By.XPath(xPathDeletCrossIcon));
            deletCrossIcon.Click();

        }

    }
}
