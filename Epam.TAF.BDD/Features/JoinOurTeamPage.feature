@Careers
@Join_our_team_Page
Feature: Join Our team Page
	As a user interested in EPAM company
	I want to be able to choose job by keywors 
	I want to be able to choose job by location 
	I want to be able to choose job by profesional skills
	In order to get open vacancies



@Keyword
@Smoke
Scenario Outline: Careers - Join our Team - Keyword - Check searched open vacancies by Keyword related to input keyword
	Given I navigate to landing page of EPAM site
	And I navigate to Join our team via Careers link on Header
	When I insert <keyword> in Keyword field on Join our Team Page
	And I click Find button on Join our Team Page
	Then I check that search result related to <keyword>

Examples:
	| keyword    |
	| develop    |
	| qa         |
	| automation |

@Location
@Smoke
Scenario Outline: Careers - Join our Team - Location - Check searched open vacancies by Location related to selected location
	Given I navigate to landing page of EPAM site
	And I navigate to Join our team via Careers link on Header
	When I open Location drop down on Join our Team Page
	And I select <country>  and <city> in Location dropdown on Join our Team Page
	And I click Find button on Join our Team Page
	Then I verify that search result related to country <country> or city <city>

Examples:
	| country   | city                    |
	| Argentina | All Cities in Argentina |
	| Armenia   | Yerevan                 |
	| Vietnam   | Ho Chi Minh             |

@Skills
@Smoke
Scenario Outline: Careers - Join our Team - Skills - Check searched open vacancies by Skills related to selected skills
	Given I navigate to landing page of EPAM site
	And I navigate to Join our team via Careers link on Header
	When I open Skills drop down on Join our Team Page
	And I select checbox <skill> in skill panel on Join our Team Page
	And I click Find button on Join our Team Page
	Then I check that search result contains selected skill <skill>

Examples:
	| skill                          |
	| Product Management             |
	| Product Design and Engineering |
	| Business and Data Analysis     |

@NoResultMessage
@Smoke
Scenario Outline: Careers - Join our Team - No Results - Check that message is present when no result related to selected keyword and location
	Given I navigate to landing page of EPAM site
	And I navigate to Join our team via Careers link on Header
	When I insert <keyword> in Keyword field on Join our Team Page
	And I open Location drop down on Join our Team Page
	And I select <country>  and <city> in Location dropdown on Join our Team Page
	And I click Find button on Join our Team Page
	Then I check that message is present that result not found

Examples:
	| keyword                 | country | city   |
	| QA Automation Team Lead | Poland  | Warsaw |
