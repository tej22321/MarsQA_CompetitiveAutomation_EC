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
    public class CertificationStepDefinition
    {
        private readonly LoginPage loginPageObject;

        private readonly CertificationPage certificationPageObject;
        public CertificationStepDefinition(LoginPage loginPage, CertificationPage certificationPage)
        {
            this.loginPageObject = loginPage;
            this.certificationPageObject = certificationPage;
        }

       
        [Given(@"navigate to Certification under profile tab")]
        public void GivenNavigateToCertificationUnderProfileTab()
        {
            loginPageObject.ClickProfileTab();
            certificationPageObject.NavigateToCertificationTab();
        }


        [When(@"user add certification data from json file with entry (.*)")]
        public void WhenUserAddCertificationDataFromJsonFileWithEntry(int index)
        {

            certificationPageObject.ClickAddNew();
            certificationPageObject.AddCertificationJsonData(index);
        }

        [Then(@"Verify Certification record is created status is (true|false)")]
        public void ThenVerifyCertificationRecordIsCreatedStatusIsTrue(bool expectedOutcome)
        {
            bool isRecordExists = certificationPageObject.VerifyCertificationRecordExists();
            if (expectedOutcome)
                Assert.IsTrue(isRecordExists, "Expected Certification record to be created but it was not");
            else
                Assert.IsFalse(isRecordExists, "Expected Certification record not to be created , but it was");

        }

        [When(@"user adds same certification record again from json file of entry (.*)")]
        public void WhenUserAddsSameCertificationRecordAgainFromJsonFileOfEntry(int index)
        {
            certificationPageObject.ClickAddNew();
            certificationPageObject.AddCertificationJsonData(index);
        }


        [Then(@"Verify duplicate Certification record is not allowed")]
        public void ThenVerifyDuplicateCertificationRecordIsNotAllowed()
        {
            bool isRecordExists = certificationPageObject.VerifyDuplicateCertificationRecordDoesntExists();
            Assert.IsTrue(isRecordExists, "Duplicate record exist in the table");
        }

        [When(@"user adds same certification record with case sensitivity from json file")]
        public void WhenUserAddsSameCertificationRecordWithCaseSensitivityFromJsonFile()
        {
            certificationPageObject.ClickAddNew();
            certificationPageObject.AddCaseSensitiveCertificationJsonData();
        }

        [When(@"user remove certification record with the entry (.*)")]
        public void WhenUserRemoveCertificationRecordWithTheEntry(int index)
        {
            certificationPageObject.removeRecord(index);
        }

        [Then(@"verify certification record is removed with (.*)")]
        public void ThenVerifyCertificationRecordIsRemovedWith(int index)
        {
            bool isRecordExists = certificationPageObject.VerifyRecordRemoved(index);
            Assert.IsTrue(isRecordExists, "Record is not removed");
        }

        [When(@"user edit a text field in the certification entry (.*)")]
        public void WhenUserEditATextFieldInTheCertificationEntry(int index)
        {
            certificationPageObject.editCertificationRecord(index);
        }

        [Then(@"verify Certification record is updated")]
        public void ThenVerifyCertificationRecordIsUpdated()
        {

            bool isRecordExists = certificationPageObject.VerifyRecordUpdated();
            Assert.IsTrue(isRecordExists, "Record is not updated");
        }

    }
}
