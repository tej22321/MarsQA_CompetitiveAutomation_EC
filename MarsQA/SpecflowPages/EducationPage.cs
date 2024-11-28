using MarsQA.Drivers;
using MarsQA.Helpers;
using MarsQA.Data;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Emit;
using System.Collections.ObjectModel;
using System.Security.Claims;

using OpenQA.Selenium.Interactions;
using AventStack.ExtentReports;



namespace MarsQA.SpecflowPages
{
    public class EducationPage
    {
        private IWebDriver driver;
        private TestData testData;
        private WaitUtils waitUtils;
      
       
        private TestData GetTestData()
        {
            if (testData == null)
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\EducationTestData.json");
                testData = JsonReader.ReadJsonFile(filePath);
            }
            return testData;
        }
        public EducationPage(CommonDriver commonDriver)
        {
            this.driver = commonDriver.Driver;
            this.waitUtils = new WaitUtils(commonDriver);
            
                 
        }

        private IWebElement educationTab => driver.FindElement(By.XPath("//a[text() = 'Education']"));

        private IWebElement addNewElement => driver.FindElement(By.XPath("//div[@data-tab='third']//div[text()='Add New']"));

        private IWebElement instituteName => driver.FindElement(By.XPath("//input[@name =\"instituteName\"]"));

        private IWebElement countryOfCollege => driver.FindElement(By.XPath("//select[@name =\"country\"]"));

        private IWebElement titleOfDegree => driver.FindElement(By.XPath("//select[@name =\"title\"]"));

        private IWebElement degree => driver.FindElement(By.XPath("//input[@name =\"degree\"]"));

        private IWebElement yearOfDegree => driver.FindElement(By.XPath("//select[@name =\"yearOfGraduation\"]"));
       
        private IWebElement addEducation => driver.FindElement(By.XPath("//input[@value = 'Add']"));
        
        private List<object> educationElementsTableRows = new List<object>();
        private IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]/div[contains(@class,'ns-box-inner')]"));
        private IWebElement ErrorMessage => driver.FindElement(By.XPath("//div[contains(@class,'ns-type-error')]/div[contains(@class,'ns-box-inner')]"));

        private IWebElement EducationRow => driver.FindElement(By.XPath($"//tbody/tr[td[text()='{CollegeNameValue}'] and td[text()='{CountryOfCollegeValue}'] and td[text() = '{TitileValue}'] and td[text() = '{DegreeValue}'] and td[text() = '{YearOfGraduationValue}']]"));

        private IWebElement UpdateRow => driver.FindElement(By.XPath("//input[@value='Update']"));
        
        private List<Education> educationList;

        private By SuccessMessageXpath = By.XPath("//div[contains(@class,'ns-type-success')]/div[contains(@class,'ns-box-inner')]");

        private By ErrorMessageXpath = By.XPath("//div[contains(@class,'ns-type-error')]/div[contains(@class,'ns-box-inner')]");

        private By MessageXpath = By.XPath("//div[contains(@class, 'ns-box-inner')]");

        private IWebElement MessageElement => driver.FindElement(MessageXpath);

        private String SuccessMessageText;
        private String ErrorMessageText;

        private String CollegeNameValue;
        private String CountryOfCollegeValue;
        private String TitileValue;
        private String DegreeValue;
        private String YearOfGraduationValue;

        private IWebElement removeElement => driver.FindElement(By.XPath("//div[@data-tab = 'third']//tbody/tr/td[6]/span/i[@class = 'remove icon']"));

        private By tbodyLocator = By.XPath("//div[@data-tab = 'third']//tbody");
        public void NavigateToEducationTab()
        {
            educationTab.Click();
        }

        public void ClickAddNew()
        {
            addNewElement.Click();
        }

        public void InstituteName(int index)
        {
           if (index >= 0 && index < educationList.Count)
            {
                if (educationList[index].instituteName.Equals("spacebar"))
                {
                    instituteName.SendKeys(Keys.Space);
                    CollegeNameValue = instituteName.GetAttribute("value");
                    return;

                }
                if (educationList[index].instituteName.Equals("longString"))
                {
                    string longString = new string('a', 10000); // Creates a string with 10,000 'a' characters.
                    instituteName.SendKeys(longString);
                    CollegeNameValue = instituteName.GetAttribute("value");
                    return;
                }
                 instituteName.Clear();
                
                instituteName.SendKeys(educationList[index].instituteName);
                CollegeNameValue = instituteName.GetAttribute("value");
                
            }
           else
            {
                throw new IndexOutOfRangeException("Invalid index for education list.");
            }
                
        }

        public void CountryofCollege(int index)
        {
            if (index >= 0 && index < educationList.Count)
            {

                SelectElement drpLevel = new SelectElement(countryOfCollege);
                
                
                if (educationList[index].country.Equals("arrows"))
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    countryOfCollege.Click();
                    Actions actions = new Actions(driver);
                    string selectedOptionText = "";

                    while (selectedOptionText != "Albania")
                    {
                        actions.SendKeys(Keys.ArrowDown).Perform();
                        actions.SendKeys(Keys.Enter).Perform();
                        waitUtils.WaitForValueToChange(countryOfCollege, selectedOptionText);
                        selectedOptionText = countryOfCollege.GetAttribute("value");
                        //Console.WriteLine(selectedOptionText+"here");
                    }
                    
                    drpLevel.SelectByText(selectedOptionText);
                    CountryOfCollegeValue = countryOfCollege.GetAttribute("value");
                    return;
                }

                if (educationList[index].country.Equals("keyboard"))
                {
                    countryOfCollege.Click();
                    Actions actions = new Actions(driver);  
                    actions.SendKeys("In").Perform();
                   
                    actions.SendKeys(Keys.Enter).Perform();
                     
                    CountryOfCollegeValue = countryOfCollege.GetAttribute("value");
                    return;
                }
                drpLevel.SelectByText(educationList[index].country);
                CountryOfCollegeValue = countryOfCollege.GetAttribute("value");
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid index for education list.");
            }

        }

        public void Title(int index)
        {

            if (index >= 0 && index < educationList.Count)
            {
                SelectElement drpLevel = new SelectElement(titleOfDegree);
                //drpLevel.SelectByText(educationList[index].title);
                //TitileValue = titleOfDegree.GetAttribute("value");


                if (educationList[index].title.Equals("arrows"))
                {
                    //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    titleOfDegree.Click();
                    Actions actions = new Actions(driver);
                    string selectedOptionText = "";

                    while (selectedOptionText != "M.Tech")
                    {
                        actions.SendKeys(Keys.ArrowDown).Perform();
                        actions.SendKeys(Keys.Enter).Perform();
                        waitUtils.WaitForValueToChange(titleOfDegree, selectedOptionText);
                        selectedOptionText = titleOfDegree.GetAttribute("value");
                        //Console.WriteLine(selectedOptionText+"here");
                    }

                    drpLevel.SelectByText(selectedOptionText);
                    TitileValue = titleOfDegree.GetAttribute("value");
                    return;
                }

                if (educationList[index].title.Equals("keyboard"))
                {
                    titleOfDegree.Click();
                    Actions actions = new Actions(driver);
                    actions.SendKeys("B").Perform();

                    actions.SendKeys(Keys.Enter).Perform();

                    TitileValue = titleOfDegree.GetAttribute("value");
                    return;
                }
                drpLevel.SelectByText(educationList[index].title);
                TitileValue = titleOfDegree.GetAttribute("value");
            }
           
            else
            {
                throw new IndexOutOfRangeException("Invalid index for education list.");
            }

        }

        public void Degree(int index)
        {

            if (index >= 0 && index < educationList.Count)
            {
                if (educationList[index].degree.Equals("longString"))
                {
                    string longString = new string('a', 10000); // Creates a string with 10,000 'a' characters.
                    degree.SendKeys(longString);
                    DegreeValue = degree.GetAttribute("value");
                    return;
                }
                if (educationList[index].degree.Equals("spacebar"))
                {
                    degree.SendKeys(Keys.Space);
                    DegreeValue = degree.GetAttribute("value");
                    return;

                }


                degree.SendKeys(educationList[index].degree);
                DegreeValue = degree.GetAttribute("value");
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid index for education list.");
            }
        }

        public void YearOfGraduaiton(int index)
        {
            SelectElement drpLevel = new SelectElement(yearOfDegree);
            if (index >= 0 && index < educationList.Count)
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                yearOfDegree.Click();
                Actions actions = new Actions(driver);
                string selectedOptionText = "";



                if (educationList[index].yearOfGraduation.Equals("arrows"))
                {
                    while (selectedOptionText != "2020")
                    {
                        actions.SendKeys(Keys.ArrowDown).Perform();
                        if (selectedOptionText == "")
                        {
                            actions.SendKeys(Keys.Enter).Perform();
                        }
                        waitUtils.WaitForValueToChange(yearOfDegree, selectedOptionText);

                        selectedOptionText = yearOfDegree.GetAttribute("value");

                        }


                    drpLevel.SelectByText(selectedOptionText);
                    YearOfGraduationValue = yearOfDegree.GetAttribute("value");
                    return;
                }


                if (educationList[index].yearOfGraduation.Equals("keyboard"))
                {
                    while (selectedOptionText != "2020")
                    {
                        actions.SendKeys("2").Perform();
                        if (selectedOptionText == "")
                        {
                            actions.SendKeys(Keys.Enter).Perform();
                        }
                        waitUtils.WaitForValueToChange(yearOfDegree, selectedOptionText);

                        selectedOptionText = yearOfDegree.GetAttribute("value");
                        
                    }

                   drpLevel.SelectByText(selectedOptionText);
                    YearOfGraduationValue = yearOfDegree.GetAttribute("value");
                    return ;
                }

                drpLevel.SelectByText(educationList[index].yearOfGraduation);
                YearOfGraduationValue = yearOfDegree.GetAttribute("value");
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid index for education list.");
            }
   
        }

        public void AddEducation()
        {


            try
            {
                addEducation.Click();
                waitUtils.waitForElementToBeVisible(MessageXpath);
                
                if (MessageElement.Displayed)
                {
                   
                    if (MessageElement.Text == "Education has been added")
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


        public void AddEducationJsonData(int index)
        {
             educationList = GetTestData().education;

            if (GetTestData() !=null)  
            {
                //index = 0;
                InstituteName(index);
                CountryofCollege(index);
                Title(index);
                Degree(index);
                YearOfGraduaiton(index);
                AddEducation();
            
                
            }
        }

        public void AddCaseSensitiveEducationJsonData()
        {
            educationList = GetTestData().education;

            if (GetTestData() != null)
            {
               int index = 1;
                InstituteName(index);
                CountryofCollege(index);
                Title(index);
                Degree(index);
                YearOfGraduaiton(index);
                AddEducation();


            }
        }


        public bool VerifyEducationRecordExists()
        {
            try
            {
         

                if ((SuccessMessageText != null))
                {
                      if(EducationRow.Displayed)
                    {
                        String instituteName = EducationRow.FindElement(By.XPath("//tbody/tr/td[2]")).Text;
                       // ExtentReportManager.LogStep(Status.Pass,"row dispalyed");

                        
                   String filePath =  CaptureScreenshot($"Record_Exists_{instituteName}");
                   ExtentReportManager.LogScreenshot(filePath);
                        removeElement.Click();
                    }
                   
                    return true;
                }
                else if ((ErrorMessageText != null))
                {
                    
                    return false;
                }

                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public String CaptureScreenshot(String fileName)
        {
 try
    {
        // Cast the driver to ITakesScreenshot
        ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
        Screenshot screenshot = screenshotDriver.GetScreenshot();

        // Save the screenshot to a specified file path
        string projectPath= Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
        string filePath = Path.Combine(projectPath,"Screenshots", $"{fileName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Ensure the directory exists
        screenshot.SaveAsFile(filePath);
        Console.WriteLine($"Screenshot saved: {filePath}");
                return filePath;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
                return null;
    }
        }

        public bool VerifyDuplicateEducationRecordDoesntExists()
        {
            try
            {
                Console.WriteLine(SuccessMessageText, ErrorMessageText);

                if ((SuccessMessageText != null  && ErrorMessageText != null))
                {
                    if (EducationRow.Displayed  && GetTableRows().Count<2)
                    {
                        removeElement.Click();
                    }
                    return true;
                }
                else if ((ErrorMessageText == null))
                {

                    return false;
                }

                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public bool VerifyDuplicateCaseSensitiveRecordDoesntExists()
        {
            try {

              //  Console.WriteLine(SuccessMessageText, ErrorMessageText);

                if ((SuccessMessageText != null && ErrorMessageText != null))
                {
                    if (EducationRow.Displayed && GetTableRows().Count < 2)
                    {
                       CleanUpEducationRecords();
                        return true;
                    }
                    
                    
                }
                else if ((ErrorMessageText == null))
                {
                    CleanUpEducationRecords();
                    return false;
                }

                return false;
            }

            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public ReadOnlyCollection<IWebElement> GetTableRows()
        {
            return driver.FindElements(By.XPath("//div[@data-tab = 'third']//tbody/tr"));
        }

        public void CleanUpEducationRecords()
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
                            IWebElement removeElement = tableRow.FindElement(By.XPath("//div[@data-tab = 'third']//tbody/tr/td[6]/span/i[@class = 'remove icon']"));
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


        public void editEducationRecord(int index)
        {
            try
            {
                String instituteName = educationList[index].instituteName;
                
                IWebElement rowElement = driver.FindElement(By.XPath($"//tbody/tr/td[text() ='{instituteName}']"));
                if (rowElement.Displayed)
                {
                    IWebElement editElement = rowElement.FindElement(By.XPath("//div[@data-tab = 'third']//tbody/tr/td[6]/span/i[@class = 'outline write icon']"));
                    editElement.Click();
                    InstituteName(1);
                    UpdateRow.Click();

                }
            }catch (Exception e) { Console.WriteLine(e.ToString()); }

        }

        public bool VerifyRecordUpdated()
        {
            String instituteName = educationList[1].instituteName;
            IWebElement rowElement = driver.FindElement(By.XPath($"//tbody/tr/td[text() = '{instituteName}']"));
            if (rowElement.Displayed)
            {
                removeElement.Click();
                return true;
            }
            else
                return false;
        }


        public void removeRecord(int index)
        {
            try
            {
                String instituteName = educationList[index].instituteName;
                IWebElement rowElement = driver.FindElement(By.XPath($"//tbody/tr/td[text() = '{instituteName}']"));

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
                String instituteName = educationList[index].instituteName;
                IWebElement rowElement = driver.FindElement(By.XPath($"//tbody/tr/td[text() = '{instituteName}']"));
                return false;
            }
            catch
            {
                return true;
            }
          
        }
    }
}
