using MarsQA.Configuration;
using MarsQA.SpecflowPages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA.StepDefinitions
{
    [Binding]
    public class EducationStepDefinition
    {
        private readonly LoginPage loginPageObject;

        private readonly EducationPage educationPageObject;
        public EducationStepDefinition(LoginPage loginPage, EducationPage educationPage) {
         this.loginPageObject = loginPage;
            this.educationPageObject = educationPage;
        }


        [Given(@"user log into MarsQA")]
        public void GivenUserLogIntoMarsQA()
        {
            loginPageObject.ClickSingIn();
            loginPageObject.EnterUserName(Config.Username); // Enter the username form the config file 
            loginPageObject.EnterPassword(Config.Password); // Enter password from the config file 
            loginPageObject.ClickLogin(); // clikc on the login button 
        }

        [Given(@"navigate to Education under profile tab")]
        public void GivenNavigateToEducationUnderProfileTab()
        {
            loginPageObject.ClickProfileTab();
            educationPageObject.NavigateToEducationTab();
        }

      [When(@"user add json data from json file with entry (.*)")]
        public void WhenUserAddJsonDataFromJsonFileWithEntry(int index)
        {
            educationPageObject.ClickAddNew();
            educationPageObject.AddEducationJsonData(index); 
        }



        [Then(@"Verify Education record is created status is (true|false)")]
        public void ThenVerifyEducationRecordIsCreatedStatusIs(bool expectedOutcome)
        {
            bool isRecordExists = educationPageObject.VerifyEducationRecordExists();
            if (expectedOutcome)
                Assert.IsTrue(isRecordExists, "Expected Education record to be created but it was not");
            else
                Assert.IsFalse(isRecordExists, "Expected Education record not to be created , but it was");
        }


        [When(@"user adds same record again from json file of entry (.*)")]
        public void WhenUserAddsSameRecordAgainFromJsonFileOfEntry(int index)
        {

            educationPageObject.ClickAddNew();
            educationPageObject.AddEducationJsonData(index);
        }

        [Then(@"Verify duplicate Education record is not allowed")]
        public void ThenVerifyDuplicateEducationRecordIsNotAllowed()
        {
            bool isRecordExists = educationPageObject.VerifyDuplicateEducationRecordDoesntExists();
            Assert.IsTrue(isRecordExists, "Duplicate record exist in the table");
        }

        [When(@"user adds same record with case sensitivity from json file")]
        public void WhenUserAddsSameRecordWithCaseSensitivityFromJsonFile()
        {
            educationPageObject.ClickAddNew();
            educationPageObject.AddCaseSensitiveEducationJsonData();
        }

        [Then(@"Verify duplicate case sensitive record is not allowed")]
        public void ThenVerifyDuplicateCaseSensitiveRecordIsNotAllowed()
        {
            bool isRecordExists = educationPageObject.VerifyDuplicateCaseSensitiveRecordDoesntExists();
            Assert.IsTrue(isRecordExists, "Duplicate case sensitive record exist in the table");
        }


        [When(@"user edit a text field in the entry (.*)")]
        public void WhenUserEditATextFieldInTheEntry(int index)
        {
            educationPageObject.editEducationRecord(index);
        }


        [Then(@"verify Education record is updated")]
        public void ThenVerifyEducationRecordIsUpdated()
        {
            bool isRecordExists = educationPageObject.VerifyRecordUpdated();
            Assert.IsTrue(isRecordExists, "Record is not updated");
        }

        [When(@"user remove record with the entry (.*)")]
        public void WhenUserRemoveRecordWithTheEntry(int index)
        {
           educationPageObject.removeRecord(index);
        }

       [Then(@"verify education record is removed with (.*)")]
        public void ThenVerifyEducationRecordIsRemovedWith(int index)
        {
            bool isRecordExists = educationPageObject.VerifyRecordRemoved(index);
            Assert.IsTrue(isRecordExists, "Record is not removed");
        }


    }
}
