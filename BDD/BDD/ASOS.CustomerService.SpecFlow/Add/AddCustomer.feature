Feature: AddCustomer
	In order to manage a list of customer
	As a customer Administrator
	I want to add a new customer
Scenario: Happy Path With Very Important client
	Given I received a very important client information
	And I have a customer's valid first name
	And I have a customer's valid sure name
	And I have a valid customer's email address
	And I have a customer's age older than twenty one
	And I retrieve the customer's company info
	And Client is very important client
	And Client has no limited credit
	Then I add this customer to the database
	And Return true value

