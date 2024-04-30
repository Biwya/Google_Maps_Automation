# Google Maps Automation Framework

---

## Intro
This framework was done as part of a technical task for the interview process.

The goal of this framework was to check the main functionalities of Google Maps form the user's perspective.

---

## Tech stack
* .NET (C#) - Main programming framework / language
* NUnit - Unit testing framework - https://nunit.org/
* Playwright - UI testing framework - https://playwright.dev/
* Reqnroll - BDD testing layer - https://reqnroll.net/
* Allure reports - Reporting tool - https://allurereport.org/

---

## Setup and first run
1. Make sure you have the right versions of prerequisite software:
   * .NET version 8
   * Java version 8 or newer (for allure reports)
   * git
2. Install Allure Reporting tool following the official steps: https://allurereport.org/docs/gettingstarted-installation/
3. Clone this framework using git. For example, open any empty folder where you want to have this framework installed, open git bash in the folder and run `git clone <insert_link_to_this_repo>`
4. Build the project by executing `dotnet build` command in your terminal opened at the location of the cloned project. Alternatively the build command can be run from any IDE supporting .NET development.
5. Change the directory to Google Maps Automation by running `cd '.\Google Maps Automation\'`
6. Use the command `pwsh bin/Debug/net8.0/playwright.ps1 install` to install the browser web drivers for Playwright. Note: You can have sever types of errors. For example:
    * If `pwsh` is not recognised, then you might not have powershell installed on the device. If you have it installed, then try replacing `pwsh` with `powershell` in the command above
    * If the issue states that running scripts is disabled on your device, then try to change the execution policy permissions on your device, by following the guide: [about Execution Policies - PowerShell | Microsoft Learn](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-7.4)
7. Run the test by executing `dotnet test` command in your terminal. Alternatively, the tests can be run using the according button in a .NET IDE. 
8. After the tests are done, move one folder up by executing `cd ..` and generate and see the test report by executing `allure serve` command in your terminal. If a test failed, a screenshot will be captured and can be seen under the Tear Down section of the failed scenario.

---

## Test run configuration
The framework supports multiple browsers and headless toggle. By default, the tests will run headless on a chromium driver.

In order to change the default configurations on run, please use the following environment variables:
* BROWSER - for selection of browser. Available options are: chrome, firefox and webkit. Example: `dotnet test -e BROWSER='firefox'`
* HEADLESS - for turning headless off. Any value except for "true" will turn off the headless mode. Example: `dotnet test -e HEADLESS=false`

Combined example: `dotnet test -e BROWSER=firefox -e HEADLESS=false`

---

## Framework structure and architecture
```C#
Google Maps Automation
-Actions
-Features
-Hooks
-Pages
-Steps
-Utilities
```

### Hooks
Hooks represent actions which are executed before or after each test, feature or the whole execution. In this case, hooks are used in order to initialise the browser instance and close it.

### Pages
Pages folder contain the classes representing a web page following the Page Object Model (POM). These classes contain the locators with which the user is expected to interact during the tests.  

### Features
The Features folder contains the feature files (BDD format test scenarios) ending with .feature. These files contain the tested flows inside the framework. The functionality is being added by Reqnroll framework.

#### How do .feature files work
The feature files represents a facade of easily readable text, which, behind the scenes bind to step definition classes by using the [Binding] attribute.  
Each feature file must contain a Feature keyword followed by the name of the feature, which represents the general business are to be tested.  
Each Feature has multiple Scenarios or Scenario Outlines:
* Scenario - represent individual test cases written in Gherkin BDD format (Given - When - Then) where each line is bound to a specific method execution in step definition classes.  
Given keyword represents steps which needs to be followed before an action is checked.  
When keyword represents an action which is supposed to be checked within the scenario.
Then keyword represents the expected outcome following one or multiple When actions.
* Scenario Outline - The same as scenario, but it allows to include variables defined in the feature file for the scenario. The variables are defined in a separate block following the Scenario Outline called Examples.  
This allows to run the same test steps with different tet data.  

For more detailed information - https://docs.reqnroll.net/latest/index.html

### Steps
This folder contains the step definition classes. As mentioned above, the step definition classes hold the bindings (i.e. the actual methods which are executed) for the steps in .feature files.  
The step definitions usually represent the middle ground between business side and technical side of the BDD focused test automation framework. Usually no logic is included in these classes.

### Actions
The actions folder hold the logic behind the steps and also makes the connection between the Steps and POMs. All the user interactions with the page, all the decisions made and other similar actions are described here.

### Utilities
This folder contains additional classes/files which are used to support the rest of the framework. 