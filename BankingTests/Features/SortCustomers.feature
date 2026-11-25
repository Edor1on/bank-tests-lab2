Feature: Sorting customers by First Name
  As a bank manager
  I want to sort the customers table by First Name
  So that I can find customers quickly

  Background:
    Given I open the XYZ Bank login page
    When I click the "Bank Manager Login" button
    And I open the "Customers" tab

  Scenario: Sort customers by First Name in descending order
    When I click the "First Name" column header 1 time(s)
    Then the customers should be sorted by First Name in descending order

  Scenario: Sort customers by First Name in ascending order
    When I click the "First Name" column header 2 time(s)
    Then the customers should be sorted by First Name in ascending order
