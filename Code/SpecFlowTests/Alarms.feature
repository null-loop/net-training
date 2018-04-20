Feature: Alarms
	In order to wake up on time for work
	As a good employee
	I need to have a reliable alarm system

Scenario: I can specify double digit hours
	Given I have set an alarm for 12:15am

Scenario: Alarm goes off in the morning
	Given I have set an alarm for 8:00am
	When the time is 8:01am
	Then the alarm for 8:00am is sounding

Scenario: Alarm goes off for multiple alarms
	Given I have set an alarm for 8:00am
	And I have set an alarm for 9:00am
	When the time is 8:01am
	Then the alarm for 8:00am is sounding
	When the time is 9:01am
	Then the alarm for 9:00am is sounding

Scenario: Alarm does not go off too early
	Given I have set an alarm for 8:00am
	When the time is 7:59am
	Then the alarm for 8:00am is not sounding

Scenario: I can turn an alarm off when it's sounding
	Given I have set an alarm for 8:00am
	When the time is 8:01am
	Then the alarm for 8:00am is sounding
	When I hit the reset button on the 8:00am alarm
	Then the alarm for 8:00am is not sounding
