Feature: Check the UI functionality of Google Maps

Scenario: The user denies the Google cookies
    Given the user accesses the 'https://www.google.com/maps' link
    When the page loads
    Then the url starts with 'https://consent.google.com/m?continue=https://www.google.com/maps'
    When the user clicks the option to deny cookies
    And the page loads
    Then the url is 'https://www.google.com/maps'