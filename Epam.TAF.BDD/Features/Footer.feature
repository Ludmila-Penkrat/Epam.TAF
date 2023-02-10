Feature: Footer
	As a user interested in EPAM Company
	I want to be able to review Footer
	In order to get information about Company



@Footer
Scenario: Epam Site - Footer - Check Investors Link
	Given I navigate to landing page of EPAM site
	And A accept all cookies on EPAM site
	When I click 'Investors' link on Footer of EPAM site
	Then I check that Investors page is opened
	