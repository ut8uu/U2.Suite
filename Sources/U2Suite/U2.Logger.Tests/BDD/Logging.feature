Feature: Logging
	This is to test how user can interact with the logger

@button_clicking
Scenario: Wipe button clicked
	Given All fields are not empty
	And Mode is 'CW'
	And Frequency is 14.044
	When User clicks the 'Wipe' button
	Then Field 'Callsign' contains ''
	And Field 'Rst Sent' contains '599'
	And Field 'Rst Received' contains '599'
	And Field 'Operator' contains ''
	And Field 'Comments' contains ''

Scenario: Save button clicked when callsign is empty
	Given All fields are not empty
	And Mode is 'CW'
	And Frequency is 14.044
	And Field 'Callsign' contains ''
	When User clicks the 'Save' button
	Then Field 'Rst Sent' is not empty
	And Field 'Rst Received' is not empty
	And Field 'Operator' is not empty
	And Field 'Comments' is not empty

Scenario: Save button clicked on correct data
	Given All fields are not empty
	And Mode is 'CW'
	And Frequency is 14.044
	And Log is empty
	When User clicks the 'Save' button
	Then All fields are empty
	And Log contains 1 record


