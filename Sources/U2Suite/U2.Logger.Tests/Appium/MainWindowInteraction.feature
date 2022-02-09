Feature: MainWindowInteraction
	A main window of the U2.Logger application

@mytag
Scenario: Save a QSO
	Given log is empty
	When user enters 'UT8UU' in Callsign
	And user clicks the Save button
	Then log contains 1 record
