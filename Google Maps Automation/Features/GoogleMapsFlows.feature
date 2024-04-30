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
    And the user is on Google Maps Page
    When the user opens the burger menu
    And the user clicks on the Language button
    And the user selects the '<language>' language
    Then the page is displayed in '<language>' language

    Examples:
      | language |
      | English  |
      | German   |

  Scenario Outline: The user checks for transport route
    Given the user accesses the 'https://www.google.com/maps' link
    And the user is on Google Maps Page
    And google maps is displayed in 'English'
    When the user clicks on Directions button
    And the user inputs 'Berlin central train station' location as STARTING_POINT
    And the user inputs 'Berlin airport' location as DESTINATION
    And the user selects <transportation_type> transportation option
    Then the user sees <comparator> <number_of_routes> routes

    Examples:
      | transportation_type | comparator | number_of_routes |
      | TRANSIT             | AT_MOST    |                6 |
      | DRIVING             | AT_LEAST   |                1 |
      | FLIGHT              | EXACTLY    |                0 |
