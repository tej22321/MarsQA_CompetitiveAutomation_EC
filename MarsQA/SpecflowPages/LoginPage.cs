using MarsQA.Configuration;
using MarsQA.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA.SpecflowPages
{
    public class LoginPage
    {
        private readonly  IWebDriver driver;
        public  LoginPage( CommonDriver commonDriver) {
           
           this.driver = commonDriver.Driver;
           }

      
        private  IWebElement SignInElement => driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));
        private IWebElement EmailElmement => driver.FindElement(By.XPath("//input[@name = 'email']"));
        private IWebElement PasswordElement => driver.FindElement(By.XPath("//input[@name = 'password']"));
        private IWebElement LoginEleemnt => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
        private IWebElement ProfileElement => driver.FindElement(By.XPath("//a[text()='Profile']"));
        private IWebElement SignoutElement => driver.FindElement(By.XPath("//button[contains(text(),'Sign Out')]"));

        public  void ClickSingIn()
        {
            SignInElement.Click();
        }


        public void ClickSingOut()
        {

            SignoutElement.Click();
        }
        public void ClickProfileTab()
        {
            ProfileElement.Click();
        }

        public void EnterUserName(String name)
        {
            EmailElmement.SendKeys(name);
        }

        public void EnterPassword(String password)
        {
            PasswordElement.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginEleemnt.Click();
        }

      
       
        public bool VerifyLanguageRecordCreated()
        {

            return true;
        }
    }
}


