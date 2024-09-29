@NoBeforeFeature
Feature: People can see what languages and skills I have

  As a user, I want to search for skills on the market, so that I can view resources matching my skills and languages.

  @tag1
  Scenario: Display resources matching entered skill and languages
    Given I navigate to the homepage
    When I enter a skill "<skill>" into the search bar
    And I click the search button
    Then I should see a list of resources matching the entered skill
    When I click one resource
    Then the results should display relevant languages and skills of the resource
