using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA.Helpers
{
   

        public static class ExtentReportManager
        {
            private static AventStack.ExtentReports.ExtentReports extent;
            private static ExtentTest test;
            private static AventStack.ExtentReports.ExtentTest scenario;

            public static void InitializeReporter(string reporterPath)
            {
                ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reporterPath);
                extent = new AventStack.ExtentReports.ExtentReports();
                extent.AttachReporter(htmlReporter);
            }

        public static ExtentTest CreateFeature(string featureName)
        {
            test = extent.CreateTest(featureName);

            return test;
        }

        public static void CreateScenario(string scenarioName)
            {
                scenario = test.CreateNode(scenarioName);
            }

            public static void LogStep(Status status, string stepInfo)
            {
            scenario.Log(status, stepInfo);
            
            }

          public static void LogScreenshot(string screenshotPath)
        {
            scenario.AddScreenCaptureFromPath(screenshotPath);
        }
      
            public static void Flush()
            {
                extent.Flush();
            }

        }

    }

