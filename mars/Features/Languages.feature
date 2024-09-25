Feature: user can add a language when less than 4 languages exist

Background:
Given user login the system 
@regression
Scenario: create a new language with valid value
	Given navigate to the language tab
	And click the Add New Button
	When input the  valid information and click the add button
	| language | level |
	| Mandarin | Basic |
	Then a new language is created
	| language | level |
	| Mandarin | Basic |
