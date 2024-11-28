using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsQA.Configuration;
using MarsQA.Drivers;
using MarsQA.Helpers;
using MarsQA.SpecflowPages;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using TechTalk.SpecFlow;






namespace MarsQA.Hooks
{
    [Binding]
    public class Hooks
    {
        
        private readonly CommonDriver commonDriver;
        private IWebDriver driver;
        
        private static string reporterpath = System.IO.Directory.GetParent(@"../../../").FullName
                                          + Path.DirectorySeparatorChar + "Result"
                                          + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy HHmmss");
        
        public Hooks(CommonDriver commonDriver) { 
        
            this.commonDriver = commonDriver;
            
                    
            
        }
       

        [BeforeTestRun]
        public static void CleanUpBeforeTests()
        {
            ExtentReportManager.InitializeReporter(reporterpath);

            


            // Initialize the WebDriver before the test run
            CommonDriver commonDriver = new CommonDriver();
            commonDriver.InitializeDriver("chrome");
            

             IWebDriver driver = commonDriver.Driver;
            driver.Navigate().GoToUrl(Config.Url);


            LoginPage loginPageObject = new LoginPage(commonDriver);
            

            loginPageObject.ClickSingIn(); // click on singIn button
            loginPageObject.EnterUserName(Config.Username); // Enter the username form the config file 
            loginPageObject.EnterPassword(Config.Password); // Enter password from the config file 
            loginPageObject.ClickLogin(); // Click on the login button 
            loginPageObject.ClickProfileTab();

            
                //test run will clear all the Education records in the table 
                EducationPage educationPage = new EducationPage(commonDriver);
                educationPage.NavigateToEducationTab();
                educationPage.CleanUpEducationRecords();
            
                //test run will clear all the Certification records in the table 
                CertificationPage certificationPage = new CertificationPage(commonDriver);
                certificationPage.NavigateToCertificationTab();
                certificationPage.CleanUpCertificationRecords();
            
            loginPageObject.ClickSingOut();
            commonDriver.CloseDriver();


        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
           ExtentTest test =  ExtentReportManager.CreateFeature(context.FeatureInfo.Title);
            
        }
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {


            // Initialize the WebDriver before each scenario
          ExtentReportManager.CreateScenario(context.ScenarioInfo.Title);
            
            commonDriver.InitializeDriver("chrome");
            
             this.driver = commonDriver.Driver;



        driver.Navigate().GoToUrl(Config.Url);
        }

        [BeforeStep]
        public void BeforeStep()
        {
          //  step = scenario;
                
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if(context.TestError == null)
            {
                ExtentReportManager.LogStep(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else
            {
                ExtentReportManager.LogStep(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            
            commonDriver.CloseDriver();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            //ExtentReportManager.Flush();
        }

        [AfterTestRun]
        public static void TearDownExtentReports()
        {
            Console.WriteLine("Flushing Extent Reports...");

            ExtentReportManager.Flush();
        }
    }

}
