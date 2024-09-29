@LoginRequired
Feature: user can operate a skill


@regression
Scenario Outline: create a new skill
	Given navigate to the skills tab
	And click the AddNew Button
	When input the "<skill>" and "<level>" and click the add button
	Then a "<message>" will be displayed to show the result
	
	Examples:
	| skill               | level  | message                                               |
	| Postman             |        | Please enter skill and experience level                       |
	| java                | Beginner | has been added to your skills.                     |
	| Java               | Beginner  | This skill is already exist in your skill list. |	
	| Java                | Beginner  | Duplicated data.                                      |
	| C++                | Expert | has been added to your skills. |
	| C#                | Beginner | has been added to your skills. |	
	| <script><Div></div></script> | Intermediate | has been added to your skills.                     |	
	| /348517&^#*%$^(*&@&@##^&@@&   | Intermediate  | has been added to your skills.                     |
	|                        | Expert  | Please enter skill and experience level                       |


Scenario Outline: user cancel to create a new skill
	Given navigate to the skills tab
	And click the AddNew Button
	When input the "<skill>" and "<level>" and click the cancel button
	Then no more skill is created
	Examples:
	| skill               | level  |
	| testing2               | Beginner  |

Scenario Outline: user can update a skill
	Given navigate to the skills tab
	And click the edit button of a "<skill>"
	When change the "<skill_name>""<level>" and click Update button
	Then a "<message>" will be displayed to show the result	
	Examples:
	| skill | skill_name | level | message                                               |
	| java | java222      | Expert | has been updated to your skills          |
	| postman | java       | Expert | is already added to your skill list. |
	| postman | Jmeter       | Intermediate | This skill is already added to your skill list. |

Scenario Outline: user can delete a skill
	Given navigate to the skills tab
	When click the delete button of a "<skill>"
	Then a "<message>" will be displayed to show the result
	
	Examples:
	| skill | message |
	| Java  |has been deleted|


