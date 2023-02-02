@Header
Feature: Header
	As a user interested in EPAM Company
	I want to be able navigate the site using Header elements
	In order to move quickly through pages

@Logo
@Smoke
Scenario Outline: Epam Site - Header - Check that click on Logo EPAM Company navigate to Landing Page from any other pages  
	Given I navigate to landing page of EPAM site
	And I navigate to other pages using page <url>
	When I click on Logo EPAM on Header
	Then I check that navigate on landing page

	Examples:
	| url                                              |
	| https://www.epam.com/about                       |
	| https://www.epam.com/about/who-we-are/contact    |
	| https://www.epam.com/web-accessibility-statement |

@HeaderLinks
@Smoke
Scenario Outline: Epam Site - Header - Check that Services Header links is opened page with the same name
	Given I navigate to landing page of EPAM site
	When I click on Header Link 'Services'
	Then I check that 'Services' link page is opened


@HeaderLinks
@Smoke
Scenario Outline: Epam Site - Header - Check that Insights Header links is opened page with the same name   
	Given I navigate to landing page of EPAM site
	When I click on Header Link 'Insights'
	Then I check that 'Insights' link page is opened

@HeaderLinks
@Smoke
Scenario Outline: Epam Site - Header - Check that About Header links is opened page with the same name   
	Given I navigate to landing page of EPAM site
	When I click on Header Link 'About'
	Then I check that 'About' link page is opened

@HeaderLinks
@Smoke
Scenario Outline: Epam Site - Header - Check that Careers Header links is opened page with the same name   
	Given I navigate to landing page of EPAM site
	When I click on Header Link 'Careers'
	Then I check that 'Careers' link page is opened