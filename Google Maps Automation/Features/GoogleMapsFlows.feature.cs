﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:1.0.0.0
//      Reqnroll Generator Version:1.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Google_Maps_Automation.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Check the UI functionality of Google Maps")]
    public partial class CheckTheUIFunctionalityOfGoogleMapsFeature
    {
        
        private Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "GoogleMapsFlows.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, NUnit.Framework.TestContext.CurrentContext.WorkerId);
            Reqnroll.FeatureInfo featureInfo = new Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Check the UI functionality of Google Maps", null, ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The user denies the Google cookies")]
        public async System.Threading.Tasks.Task TheUserDeniesTheGoogleCookies()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("The user denies the Google cookies", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 3
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 4
    await testRunner.GivenAsync("the user accesses the \'https://www.google.com/maps\' link", ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 5
    await testRunner.WhenAsync("the page loads", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 6
    await testRunner.ThenAsync("the url starts with \'https://consent.google.com/m?continue=https://www.google.com" +
                        "/maps\'", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
#line 7
    await testRunner.WhenAsync("the user clicks the option to deny cookies", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 8
    await testRunner.AndAsync("the page loads", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 9
    await testRunner.ThenAsync("the url is \'https://www.google.com/maps\'", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The user changes language of the maps")]
        [NUnit.Framework.TestCaseAttribute("English", null)]
        [NUnit.Framework.TestCaseAttribute("German", null)]
        public async System.Threading.Tasks.Task TheUserChangesLanguageOfTheMaps(string language, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("language", language);
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("The user changes language of the maps", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 12
    await testRunner.GivenAsync("the user accesses the \'https://www.google.com/maps\' link", ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 13
    await testRunner.AndAsync("the user continues by denying Google cookies", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 14
    await testRunner.WhenAsync("the user opens the burger menu", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 15
    await testRunner.AndAsync("the user clicks on the Language button", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 16
    await testRunner.AndAsync(string.Format("the user selects the \'{0}\' language", language), ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 17
    await testRunner.ThenAsync(string.Format("the page is displayed in \'{0}\' language", language), ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
