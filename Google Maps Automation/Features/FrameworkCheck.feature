Feature: Open Playwright

This feature should check if framework configuration works

  Scenario: Test the framework setup
    Given the user accesses the 'https://playwright.dev/' link
    When the user clicks on the 'Get started' link
    Then the user is redirected to the page with url ending with "intro"
