Feature: Test BidiButton

Scenario: Click a BidiButton
	Given I open the index page
		And I click the button
	When I wait for state change
	Then Must have value of 1

Scenario: Click a BidiButton twice and then right click once
	Given I open the index page
		And I click the button
		And I click the button
		And I click the button
		And I right click the button
	When I wait for state change
	Then Must have value of 2

Scenario: Right click a BidiButton three times to check underflow
	Given I open the index page
		And I right click the button
		And I right click the button
		And I right click the button
	When I wait for state change
	Then Must have value of 0