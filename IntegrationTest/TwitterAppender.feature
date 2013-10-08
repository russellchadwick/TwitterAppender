Feature: TwitterAppender
	In order to have my logs in the cloud
	As a noob developer
	I want to be able to tweet my logs

Scenario: Tweet my logs
	Given I have configured log4net in configuration
	When I log a statement
	Then the result should be sent through twitter APIs
