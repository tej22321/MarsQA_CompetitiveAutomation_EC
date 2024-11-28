using MarsQA.Data;
using MarsQA.Drivers;
using MarsQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA.SpecflowPages
{
    public class CertificationPage
    {
        private IWebDriver driver;
        private TestData testData;
        private WaitUtils waitUtils;
        public CertificationPage(CommonDriver commonDriver)
        {
            this.driver = commonDriver.Driver;
            this.waitUtils = new WaitUtils(commonDriver);
        }
        private TestData GetTestData()
        {
            if (testData == null)
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CertificationTestData.json");
                testData = JsonReader.ReadJsonFile(filePath);
            }
            return testData;
        }

        private IWebElement certificationTab => driver.FindElement(By.XPath("//a[text() = 'Certifications']"));
        private IWebElement addNewElement => driver.FindElement(By.XPath("//div[@data-tab='fourth']//div[text()='Add New']"));

        private List<Certification> certificationList;

        private IWebElement certificationName => driver.FindElement(By.XPath("//input[@name =\"certificationName\"]"));

        private IWebElement certificationFrom => driver.FindElement(By.XPath("//input[@name =\"certificationFrom\"]"));

        private IWebElement certificationYear => driver.FindElement(By.XPath("//select[@name =\"certificationYear\"]"));

        private IWebElement addCertification => driver.FindElement(By.XPath("//input[@value = 'Add']"));
       
        private String certificationNameValue;

        private String certificationFromValue;

        private String CertificationYearValue;

        private String SuccessMessageText;

        private String ErrorMessageText;


        private By MessageXpath = By.XPath("//div[contains(@class, 'ns-box-inner')]");

        private IWebElement MessageElement => driver.FindElement(MessageXpath);

        private IWebElement CertificationRow => driver.FindElement(By.XPath($"//tbody/tr[td[text()='{certificationNameValue}'] and td[text()='{certificationFromValue}'] and td[text() = '{CertificationYearValue}']]"));
        private IWebElement UpdateRow => driver.FindElement(By.XPath("//input[@value='Update']"));

        private IWebElement removeElement => driver.FindElement(By.XPath("//div[@data-tab = 'fourth']//tbody/tr/td[4]/span/i[@class = 'remove icon']"));
       
        private By tbodyLocator = By.XPath("//div[@data-tab = 'fourth']//tbody");

        public ReadOnlyCollection<IWebElement> GetTableRows()
        {
            return driver.FindElements(By.XPath("//div[@data-tab = 'fourth']//tbody/tr"));
        }
        public void NavigateToCertificationTab()
        {

            certificationTab.Click();
        }

        public void ClickAddNew()
        {
            addNewElement.Click();
        }
        public void AddCertificationJsonData(int index)
        {
            certificationList = GetTestData().certification;

            if (GetTestData() != null)
            {

                CertificationName(index);
                CertificationFrom(index);
                CertificationYear(index);
                AddCertification();

            }
        }

        public void CertificationName(int index)
        {
            if (index >= 0 && index < certificationList.Count)
            {
                /*if (educationList[index].instituteName.Equals("longString"))
                {
                    string longString = new string('a', 10000); // Creates a string with 10,000 'a' characters.
                    instituteName.SendKeys(longString);
                    CollegeNameValue = instituteName.GetAttribute("value");
                    return;
                }*/
                
                if (certificationList[index].certificationName.Equals("spacebar"))
                {

                    certificationName.SendKeys(Keys.Space);
                    certificationNameValue = certificationName.GetAttribute("value");
                    return;
                }

                certificationName.Clear();

                certificationName.SendKeys(certificationList[index].certificationName);
                certificationNameValue = certificationName.GetAttribute("value");

            }
            else
            {
                throw new IndexOutOfRangeException("Invalid index for education list.");
            }

        }

        public void CertificationFrom(int index)
        {
            if (index >= 0 && index < certificationList.Count)
            {
                /*if (educationList[index].instituteName.Equals("longString"))
                {
                    string longString = new string('a', 10000); // Creates a string with 10,000 'a' characters.
                    instituteName.SendKeys(longString);
                    CollegeNameValue = instituteName.GetAttribute("value");
                    return;
                }*/

                if (certificationList[index].certificationFrom.Equals("spacebar"))
                {

                    certificationFrom.SendKeys(Keys.Space);
                    certificationFromValue = certificationName.GetAttribute("value");
                    return;
                }


                certificationFrom.Clear();

                certificationFrom.SendKeys(certificationList[index].certificationFrom);
                certificationFromValue = certificationName.GetAttribute("value");

            }
            else
            {
                throw new IndexOutOfRangeException("Invalid index for certification list.");
            }

        }




        public void CertificationYear(int index)
        {
            if (index >= 0 && index < certificationList.Count)
            {

                SelectElement drpLevel = new SelectElement(certificationYear);


                if (certificationList[index].certificationYear.Equals("arrows"))
                {
                    //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                    certificationYear.Click();
                    Actions actions = new Actions(driver);
                    string selectedOptionText = "";

                    while (selectedOptionText != "2015")
                    {
                        actions.SendKeys(Keys.ArrowDown).Perform();
                        if (selectedOptionText == "") {
                        actions.SendKeys(Keys.Enter).Perform();
                    }
                        waitUtils.WaitForValueToChange(certificationYear, selectedOptionText);
                        
                        selectedOptionText = certificationYear.GetAttribute("value");
                        
                       // actions.MoveToElement(certificationYear).Perform();
                        
                    }
                     
                   
                    drpLevel.SelectByText(selectedOptionText);
                    CertificationYearValue = certificationYear.GetAttribute("value");
                    return;
                }


                
                if (certificationList[index].certificationYear.Equals("keyboard"))
                {
                    string selectedOptionText = "";
                    while (selectedOptionText != "2015")
                    {

                        certificationYear.Click();
                        Actions actions = new Actions(driver);
                        actions.SendKeys("2").Perform();

                        selectedOptionText = certificationYear.GetAttribute("value");

                    }
                    drpLevel.SelectByText(selectedOptionText);
                    CertificationYearValue = certificationYear.GetAttribute("value");
                    return;
                }
                drpLevel.SelectByText(certificationList[index].certificationYear);
                CertificationYearValue = certificationYear.GetAttribute("value");
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid index for education list.");
            }

        }

       public void AddCertification()
        {


            try
            {
                addCertification.Click();
                waitUtils.waitForElementToBeVisible(MessageXpath);

                if (MessageElement.Displayed)
                {

                    if (MessageElement.Text.Contains("has been added to your certification"))
                    {
                        SuccessMessageText = MessageElement.Text;
                        Console.WriteLine(SuccessMessageText);
                        waitUtils.waitForElementToBeInvisible(MessageXpath);
                    }
                    else
                    {
                        ErrorMessageText = MessageElement.Text;
                        Console.WriteLine(ErrorMessageText);
                        waitUtils.waitForElementToBeInvisible(MessageXpath);

                    }
                }
            }

            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public bool VerifyCertificationRecordExists()
        {
            try
            {


                if ((SuccessMessageText != null))
                {
                    if (CertificationRow.Displayed)
                    {
                       /* String certificationName = CertificationRow.FindElement(By.XPath("//tbody/tr/td[2]")).Text;
                        // ExtentReportManager.LogStep(Status.Pass,"row dispalyed");


                        String filePath = CaptureScreenshot($"Record_Exists_{certificationName}");
                        ExtentReportManager.LogScreenshot(filePath);*/
                       Console.Write(SuccessMessageText+"here in true");
                        removeElement.Click();
                    }

                    return true;
                }
                else if ((ErrorMessageText != null))
                {
                    Console.Write(ErrorMessageText + "here in false");
                    removeElement.Click();
                    return false;
                }

                return false;
            }
            catch (NoSuchElementException)
            {

                //removeElement.Click();
                return false;
            }
        }

        public bool VerifyDuplicateCertificationRecordDoesntExists()
        {
            try
            {
                Console.WriteLine(SuccessMessageText, ErrorMessageText);

                if ((SuccessMessageText != null && ErrorMessageText != null))
                {
                    if (CertificationRow.Displayed && GetTableRows().Count < 2)
                    {
                        removeElement.Click();
                    }
                    return true;
                }
                else if ((ErrorMessageText == null))
                {
                    removeElement.Click();
                    return false;
                }

                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void AddCaseSensitiveCertificationJsonData()
        {
            certificationList = GetTestData().certification;

            if (GetTestData() != null)
            {
                int index = 1;
                CertificationName(index);
                CertificationFrom(index);
                CertificationYear(index);
                AddCertification();


            }
        }

        public void CleanUpCertificationRecords()
        {

            try
            {

                if (IsElementPresent(driver, tbodyLocator))
                {
                    ReadOnlyCollection<IWebElement> tableRows = GetTableRows();
                    while (tableRows.Count > 0)
                    {
                        foreach (IWebElement tableRow in tableRows)
                        {
                            // var removeElements = driver.FindElements(By.XPath("//div[@data-tab = 'third']//tbody/tr/td[6]/span/i[@class = 'remove icon']"));
                            //Console.WriteLine("Found remove icons: " + removeElements.Count);
                            // waitUtils.waitForElementToBeVisible(By.XPath("//div[@data-tab = 'third']//tbody/tr/td[6]/span/i[@class = 'remove icon']"));
                            IWebElement removeElement = tableRow.FindElement(By.XPath("//div[@data-tab = 'fourth']//tbody/tr/td[4]/span/i[@class = 'remove icon']"));
                            removeElement.Click();
                            waitUtils.waitForElementToBeInvisible(By.XPath("//div[contains(@class,'ns-type-success')]/div[contains(@class,'ns-box-inner')]"));
                            // Re-fetch the tableRows after removing an element
                            tableRows = GetTableRows();

                            // Break out of the foreach loop to restart from the first row, since the DOM has been updated
                            break;
                        }


                    }


                }
                else
                {
                    Console.WriteLine("No records found.");
                }

                static bool IsElementPresent(IWebDriver driver, By locator)
                {
                    try
                    {
                        driver.FindElement(locator);
                        return true;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }

        }
        public void removeRecord(int index)
        {
            try
            {
                String certificationName = certificationList[index].certificationName;
                IWebElement rowElement = driver.FindElement(By.XPath($"//tbody/tr/td[text() = '{certificationName}']"));

                if (rowElement.Displayed)
                {
                    removeElement.Click();

                    SuccessMessageText = MessageElement.Text;
                    Console.WriteLine(SuccessMessageText);
                    waitUtils.waitForElementToBeInvisible(MessageXpath);

                }
                else
                {
                    Console.WriteLine("No such record");

                    ErrorMessageText = MessageElement.Text;
                    Console.WriteLine(ErrorMessageText);
                    waitUtils.waitForElementToBeInvisible(MessageXpath);
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }

        }

        public bool VerifyRecordRemoved(int index)
        {
            try
            {
                String certificationName = certificationList[index].certificationName;
                IWebElement rowElement = driver.FindElement(By.XPath($"//tbody/tr/td[text() = '{certificationName}']"));
                return false;
            }
            catch
            {
                return true;
            }

        }

        public void editCertificationRecord(int index)
        {
            try
            {
                String certificationName = certificationList[index].certificationName;

                IWebElement rowElement = driver.FindElement(By.XPath($"//tbody/tr/td[text() ='{certificationName}']"));
                if (rowElement.Displayed)
                {
                    IWebElement editElement = rowElement.FindElement(By.XPath("//div[@data-tab = 'fourth']//tbody/tr/td[4]/span/i[@class = 'outline write icon']"));
                    editElement.Click();
                    CertificationName(1);
                    UpdateRow.Click();

                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }

        }

        public bool VerifyRecordUpdated()
        {
            String certificationName = certificationList[1].certificationName;
            IWebElement rowElement = driver.FindElement(By.XPath($"//tbody/tr/td[text() = '{certificationName}']"));
            if (rowElement.Displayed)
            {
                removeElement.Click();
                return true;
            }
            else
                return false;
        }



    }
}
