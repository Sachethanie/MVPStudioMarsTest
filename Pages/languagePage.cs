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
        public void SuccessfullyAddnewLanguage(IWebDriver driver, string languageToBeAdd, string languageLevelToBeAdd)
        {

            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
          
            WaitHelper.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input", 30);

            IWebElement addLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            IWebElement addLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            SelectElement dropdown = new SelectElement(addLanguageLevel);

            addLanguage.SendKeys(languageToBeAdd);
            dropdown.SelectByText(languageLevelToBeAdd);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(languageLevelToBeAdd));

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();

            //Assertion
            WaitHelper.WaitToBeVisible(driver, "ClassName", "ns-box",30);
            IWebElement toastMessageElement = driver.FindElement(By.ClassName("ns-box"));

           // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));
            
            string expectedMessage = $"{languageToBeAdd} has been added to your languages";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));


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

        public void CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(IWebDriver driver)
        {
            string languageToBeAdd = "Spanish";

            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            //Assertion

            WaitHelper.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input", 30);

            IWebElement addLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            
            addLanguage.SendKeys(languageToBeAdd);

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();
            //thred sleep 
            WaitHelper.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]", 30);

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));
            IWebElement toastMessageElement1 = driver.FindElement(By.ClassName("ns-box"));


            string expectedMessage = "Please enter language and level";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        public void CannotBeAbleToAddExistingLanguageAndLanguageLevelAsANewLanguage(IWebDriver driver)
        {
            string languageToBeAdd = "English";
            string languageLevelToBeAdd = "Basic";


            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            //Assertion

            WaitHelper.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input", 30);

            IWebElement addLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            IWebElement addLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            SelectElement dropdown = new SelectElement(addLanguageLevel);

            addLanguage.SendKeys(languageToBeAdd);
            dropdown.SelectByText(languageLevelToBeAdd);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(languageLevelToBeAdd));

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();
            //thred sleep 
            WaitHelper.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]", 30);

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));
            //IWebElement toastMessageElement1 = driver.FindElement(By.ClassName("ns-box"));


            string expectedMessage = "This language is already exist in your language list";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));


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

        public void SuccessfullyEditExistingLanguageAndLanguageLevel(IWebDriver driver)
        {
            string languageToBeEdit = "Sinhala";           
            string languageLevelToBeEdit2 = "Coversational";
          
            IWebElement editPencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            editPencilIcon.Click();


            IWebElement addLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            addLanguage.Clear();
            addLanguage.SendKeys(languageToBeEdit);

            IWebElement addLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            SelectElement dropdown = new SelectElement(addLanguageLevel);
           addLanguageLevel.Click();
           
            addLanguageLevel.SendKeys(languageLevelToBeEdit2);
            addLanguageLevel.SendKeys(Keys.Enter);


            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();           

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));        

            string expectedMessage = "Sinhala has been updated to your languages";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage)); 

        }

        public void SuccsfullyEditOnlyExistingLanguageToANewLanguageWithoutEditLanguageLevel(IWebDriver driver) 
        {
            string languageToBeEdit = "Swedish";

            IWebElement editPencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            editPencilIcon.Click();

            IWebElement addLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            addLanguage.Clear();
            addLanguage.SendKeys(languageToBeEdit);

            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            WaitHelper.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]", 30);

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));
            
            string expectedMessage = $"{languageToBeEdit} has been updated to your languages";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));

        }
        /*
        public void SuccsfullyEditLanguageLevelWithoutEditLanguage(IWebDriver driver)
        {           
            string languageLevelToBeEdit2 = "Coversational";          

            IWebElement editPencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            editPencilIcon.Click();

            IWebElement addLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            SelectElement dropdown = new SelectElement(addLanguageLevel);
            addLanguageLevel.Click();

            addLanguageLevel.SendKeys(languageLevelToBeEdit2);
            addLanguageLevel.SendKeys(Keys.Enter);


            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            WaitHelper.waitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]", 30);

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));
            //IWebElement toastMessageElement1 = driver.FindElement(By.ClassName("ns-box"));


            string expectedMessage = "Sinhala has been updated to your languages";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));

        }
        */

        public void CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(IWebDriver driver)
        {
            string languageToBeEdit = "Swedish";
            string languageLevelToBeEdit2 = "Conversational";

            IWebElement editPencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            editPencilIcon.Click();


            IWebElement addLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            addLanguage.Clear();
            addLanguage.SendKeys(languageToBeEdit);

            IWebElement addLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            SelectElement dropdown = new SelectElement(addLanguageLevel);
            addLanguageLevel.Click();

            addLanguageLevel.SendKeys(languageLevelToBeEdit2);
            addLanguageLevel.SendKeys(Keys.Enter);

            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            WaitHelper.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]", 30);

            //Assertion
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement toastMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ns-box")));
            


            string expectedMessage = "This language is already added to your language list.";
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));


        }


        public void deleteExistingLanguage(IWebDriver driver) 
        {
        

        }

    }
}
