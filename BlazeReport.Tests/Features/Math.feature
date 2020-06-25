Feature: Math
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Report
Scenario: Add two numbers
	Given I have entered 50
	And then entered 70
	When I press add
	Then then result should be 120
