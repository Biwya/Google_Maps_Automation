@E2E
Feature: Recreate trips using Google Maps based on June's Journey

  @JunesJourney
  Scenario: June's Journey fan plans a trip from Berlin through Google Maps based on the first chapters of the game
    Given the user accesses the 'https://www.google.com/maps' link
    And the user is on Google Maps Page
    And google maps is displayed in 'English'
    When the user clicks on Directions button
    And the user inputs 'Wooga office Berlin' location as STARTING_POINT
    And the user inputs 'Berlin airport' location as DESTINATION
    And the user selects TRANSIT transportation option
    Then the user sees AT_LEAST 3 routes
    When the user reverses the starting point and destination locations
    And the user clears the DESTINATION location
    And the user inputs 'New York airport' location as DESTINATION
    And the user selects FLIGHT transportation option
    Then the user sees AT_LEAST 1 route
    When the user closes the directions screen
    Then the user sees the general search input field
    When the user inputs 'Car rental New York' location as LOCATION
    And the user clicks on Search button
    Then the user sees AT_LEAST 10 search results
    When the user clears the LOCATION location
    And the user inputs '1920s Cafe New York' location as LOCATION
    And the user clicks on Search button
    And the user opens the search filters
    And the user filters by rating of 4.0 stars
    And the user confirms the filtering options
    Then all locations have the rating of AT_LEAST 4.0 stars
    When the user closes the search location screen
    And the user clicks on Directions button
    And the user inputs 'New York International Airpot' location as STARTING_POINT
    And the user inputs 'Richmond University' location as DESTINATION
    And the user selects DRIVING transportation option
    Then the user sees AT_LEAST 1 route
    When the user reverses the starting point and destination locations
    Then the user sees AT_LEAST 1 route
    When the user reverses the starting point and destination locations
    And the user clears the DESTINATION location
    And the user inputs 'Berlin airport' location as DESTINATION
    And the user selects FLIGHT transportation option
    Then the user sees AT_LEAST 1 route
