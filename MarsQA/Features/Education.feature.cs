﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace MarsQA.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Adding Education to a user profile")]
    public partial class AddingEducationToAUserProfileFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Education.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Adding Education to a user profile", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
 #line hidden
#line 4
   testRunner.Given("user log into MarsQA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 5
   testRunner.And("navigate to Education under profile tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add new education entry from json data file to user profile")]
        [NUnit.Framework.CategoryAttribute("addEducation")]
        [NUnit.Framework.TestCaseAttribute("0", "true", null)]
        [NUnit.Framework.TestCaseAttribute("2", "false", null)]
        [NUnit.Framework.TestCaseAttribute("3", "false", null)]
        [NUnit.Framework.TestCaseAttribute("4", "false", null)]
        [NUnit.Framework.TestCaseAttribute("5", "false", null)]
        [NUnit.Framework.TestCaseAttribute("6", "false", null)]
        [NUnit.Framework.TestCaseAttribute("7", "false", null)]
        [NUnit.Framework.TestCaseAttribute("8", "false", null)]
        [NUnit.Framework.TestCaseAttribute("9", "false", null)]
        [NUnit.Framework.TestCaseAttribute("10", "false", null)]
        [NUnit.Framework.TestCaseAttribute("11", "false", null)]
        [NUnit.Framework.TestCaseAttribute("12", "false", null)]
        [NUnit.Framework.TestCaseAttribute("13", "false", null)]
        [NUnit.Framework.TestCaseAttribute("14", "false", null)]
        [NUnit.Framework.TestCaseAttribute("15", "false", null)]
        [NUnit.Framework.TestCaseAttribute("16", "true", null)]
        [NUnit.Framework.TestCaseAttribute("17", "true", null)]
        [NUnit.Framework.TestCaseAttribute("18", "true", null)]
        [NUnit.Framework.TestCaseAttribute("19", "true", null)]
        [NUnit.Framework.TestCaseAttribute("20", "true", null)]
        [NUnit.Framework.TestCaseAttribute("21", "true", null)]
        public void AddNewEducationEntryFromJsonDataFileToUserProfile(string index, string expectedoutcome, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "addEducation"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("index", index);
            argumentsOfScenario.Add("expectedoutcome", expectedoutcome);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add new education entry from json data file to user profile", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 9
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
 this.FeatureBackground();
#line hidden
#line 11
  testRunner.When(string.Format("user add json data from json file with entry {0}", index), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 12
  testRunner.Then(string.Format("Verify Education record is created status is {0}", expectedoutcome), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify duplicate Education record is not allowed for duplicate entry")]
        [NUnit.Framework.CategoryAttribute("checkDuplicate")]
        [NUnit.Framework.TestCaseAttribute("0", null)]
        public void VerifyDuplicateEducationRecordIsNotAllowedForDuplicateEntry(string index, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "checkDuplicate"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("index", index);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify duplicate Education record is not allowed for duplicate entry", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 39
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
 this.FeatureBackground();
#line hidden
#line 41
   testRunner.When(string.Format("user add json data from json file with entry {0}", index), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 42
 testRunner.And(string.Format("user adds same record again from json file of entry {0}", index), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 43
  testRunner.Then("Verify duplicate Education record is not allowed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify case sensitive duplicate Education record is not allowed for duplicate ent" +
            "ry")]
        [NUnit.Framework.CategoryAttribute("caseSensitiveDuplicateData")]
        [NUnit.Framework.TestCaseAttribute("0", null)]
        public void VerifyCaseSensitiveDuplicateEducationRecordIsNotAllowedForDuplicateEntry(string index, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "caseSensitiveDuplicateData"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("index", index);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify case sensitive duplicate Education record is not allowed for duplicate ent" +
                    "ry", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 52
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
 this.FeatureBackground();
#line hidden
#line 54
   testRunner.When(string.Format("user add json data from json file with entry {0}", index), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 55
 testRunner.And("user adds same record with case sensitivity from json file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
  testRunner.Then("Verify duplicate case sensitive record is not allowed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Edit Educaiton Record")]
        [NUnit.Framework.CategoryAttribute("editEducationRecord")]
        [NUnit.Framework.TestCaseAttribute("0", null)]
        public void EditEducaitonRecord(string index, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "editEducationRecord"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("index", index);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit Educaiton Record", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 63
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
 this.FeatureBackground();
#line hidden
#line 65
testRunner.When(string.Format("user add json data from json file with entry {0}", index), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 66
testRunner.And(string.Format("user edit a text field in the entry {0}", index), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
testRunner.Then("verify Education record is updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Remove Educaiton Record")]
        [NUnit.Framework.CategoryAttribute("removeEducationRecord")]
        [NUnit.Framework.TestCaseAttribute("0", null)]
        public void RemoveEducaitonRecord(string index, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "removeEducationRecord"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("index", index);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove Educaiton Record", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 75
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
 this.FeatureBackground();
#line hidden
#line 77
testRunner.When(string.Format("user add json data from json file with entry {0}", index), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 78
testRunner.And(string.Format("user remove record with the entry {0}", index), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 79
testRunner.Then(string.Format("verify education record is removed with {0}", index), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
