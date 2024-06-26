using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsTest.Utils
{
    internal class WaitHelper : CommonDriver
    {
        public static void WaitToBeClickable(IWebDriver driver, String locatorType, string locatorValue, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            if (locatorType == "Id")
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            }
            else if (locatorType == "Xpath")
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
            else if (locatorType == "CssSelector")
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
            }
            else if (locatorType == "Name")
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(locatorValue)));
            }
            else if (locatorType == "ClassName")
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(locatorValue)));
            }
        }

        public static void WaitToBeVisible(IWebDriver driver, String locatorType, string locatorValue, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            if (locatorType == "Id")

            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
            }
            else if (locatorType == "Xpath")
            {

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));

            }
            else if (locatorType == "CssSelector")
            {

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));

            }
            else if (locatorType == "Name")
            {

                wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locatorValue)));

            }
            else if (locatorType == "ClassName")
            {

                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));

            }
        }

    }
}
