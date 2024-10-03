@LoginRequired
Feature: user can operate a language


@regression
Scenario Outline: create a new language
	Given navigate to the language tab
	And click the Add New Button
	When input the  "<language>" and "<level>" and click the add button
	Then a "<message>" will be display to show the result
	
Examples:
	| language                     | level  | message                                               |
	| Mandarin                     | Basic  | has been added to your languages.                     |
	| mandarin                     |        | Please enter language and level                       |
	| English                      | Fluent | has been added to your languages.                     |
	| English                      | Fluent | This language is already exist in your language list. |
	| english                      | Fluent | This language is already exist in your language list. |
	| English                      | Basic  | Duplicated data.                                      |
	|                              | Basic  | Please enter language and level                       |
	
	| 348517&^#*@&@##^&@@&         | Basic  | has been added to your languages.                     |
	| <script><Div></div></script> | Basic  | has been added to your languages.                     |

Scenario: user cancel to create a new language
	Given navigate to the language tab
	And click the Add New Button
	When input the  valid information and click the Cancel button
		| language | level |
		| Mandarin | Basic |
	Then no more language is created

Scenario Outline: user can update a language
	Given navigate to the language tab
	And click the edit Button of a "<language>"
	When change the "<language_name>" and "<level>" and click Update button
	Then a "<message>" will be display to show the result
	
Examples:
	| language | language_name | level  | message                                               |
	| Mandarin | mandarin      | Basic  | has been updated to your languages                    |
	| Mandarin | English       | Basic  | This language is already added to your language list. |
	| Mandarin | English       | Fluent | This language is already added to your language list. |

Scenario Outline: user can delete a language
	Given navigate to the language tab
	When click the delete Button of a "<language>"
	Then a "<message>" will be display to show the result
	
Examples:
	| language | message                              |
	| English  | has been deleted from your languages |

Scenario: user can see the AddNew button when language number less than 4
	Given navigate to the language tab
	When the user has 4 languages
	Then the button should not be visible
	When user delete a language
	Then the button should be visible