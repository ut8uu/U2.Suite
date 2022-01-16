Feature: Logging
	This is to test how user can interact with the logger

@button_clicking
Scenario: Wipe button clicked
	Given Field 'Callsign' contains 'UT8UU'
	And Field 'Rst Sent' contains '599'
	And Field 'Rst Received' contains '599'
	And Field 'Operator' contains 'Sergey'
	And Field 'Comments' contains 'Strong signal'
	When User clicks the 'Wipe' button
	Then Field 'Callsign' contains ''
	And Field 'Rst Sent' contains ''
	And Field 'Rst Received' contains ''
	And Field 'Operator' contains ''
	And Field 'Comments' contains ''
