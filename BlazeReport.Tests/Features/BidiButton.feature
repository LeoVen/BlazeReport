Feature: Test BidiButton

@UseWebDriver
Scenario: Click a BidiButton
	Given I open the index page
		And I click the button
	When I wait for 1000 ms
	Then Must have value of 1
	
@UseWebDriver
@Report
Scenario: Click a BidiButton thrice and then right click once
	Given I open the index page
		And I click the button
		And I click the button
		And I click the button
		And I right click the button
	When I wait for 1000 ms
	Then Must have value of 2

@UseWebDriver
@Report
Scenario: Right click a BidiButton three times to check underflow
	Given I open the index page
		And I right click the button
		And I right click the button
		And I right click the button
	When I wait for 1000 ms
	Then Must have value of 0
