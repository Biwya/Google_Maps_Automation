Feature: Check the UI functionality of Google Maps

  Scenario: The user denies the Google cookies
    Given the user accesses the 'https://www.google.com/maps' link
    When the page loads
    Then the url starts with 'https://consent.google.com/m?continue=https://www.google.com/maps'
    When the user clicks the option to deny cookies
    And the page loads
    Then the url is 'https://www.google.com/maps'

  Scenario Outline: The user changes language of the maps
    Given the user accesses the 'https://www.google.com/maps' link
    And the user continues by denying Google cookies
    When the user opens the burger menu
    And the user clicks on the Language button
    And the user selects the '<language>' language
    Then the page is displayed in '<language>' language

    Examples:
      | language |
      | English  |
      | German   |
