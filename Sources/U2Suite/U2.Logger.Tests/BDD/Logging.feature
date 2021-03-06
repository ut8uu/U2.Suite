 Feature:  Logging
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
	And Log is empty
	When User clicks the 'Save' button
	Then Field 'Rst Sent' is not empty
	And Field 'Rst Received' is not empty
	And Field 'Operator' is not empty
	And Field 'Comments' is not empty
	And Log contains 0 records

Scenario: Save button clicked on correct data
	Given All fields are not empty
	And Mode is 'CW'
	And Frequency is 14.044
	And Log is empty
	When User clicks the 'Save' button
	Then All fields are empty
	And Log contains 1 records 

Scenario: Can handle bad frequency
	Given All fields are not empty
	And Realtime is turned 'off'
	And Frequency is 8
	Then Exception with text 'Frequency 8 not recognized as a valid one.' was thrown

Scenario Outline: Can convert good frequency
	Given All fields are not empty
	And Mode is 'CW'
	And Frequency is <freq>
	Then Band is '<band>'
Scenarios: 
| freq   | band |
| 1.820  | 160m |
| 3.505  | 80m  |
| 7.024  | 40m  |
| 10.124 | 30m  |
| 14.044 | 20m  |
| 18.120 | 17m  |
| 21.044 | 15m  |
| 24.900 | 12m  |
| 28.044 | 10m  |
| 50.044 | 6m   |
