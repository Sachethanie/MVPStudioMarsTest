using MarsTest.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsTest.Pages
{
    public class LoginPage
    {
        public void loginPage(IWebDriver driver)
        {
            try
            {
                IWebElement signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
                signInButton.Click();
                //Wait

                IWebElement eMail = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
                IWebElement password = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
                IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

                eMail.SendKeys("sachethaniei@gmail.com");
                password.SendKeys("password");
                loginButton.Click();
                //Wait 

                WaitHelper.WaitToBeVisible(driver, "XPath", "//*[@id=account-profile-section]/div/div[1]/div[2]/div/a[2]/button", 30);
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {

                Assert.Fail($"profile Page hasn't launched. {ex.Message}" );
            }


        }
    }
}
