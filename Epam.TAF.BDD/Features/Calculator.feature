@Calculator
Feature: Calculator
	As a student
	I want to be able to perform basic arithmetic operation
	In order to get high scare on tests

@Sum
@Smoke
Scenario: Calculator - Check Sum
	Given I provide number <operand1> into calculator
	And I provide number <operand2> into calculator
	When I get 'Sum' of numbers entered
	Then Result of calculation is <result>

Examples: 
	| operand1 | operand2 | result |
	| 2        | 5        | 7      |
	| -5       | 10       | 5      |
	| 0,5      | 0,25     | 0,75   |
	| -100     | -2       | -102   |

@Diff
@Smoke
Scenario: Calculator - Check Diff
	Given I provide number <operand1> into calculator
	And I provide number <operand2> into calculator
	When I get 'Diff' of numbers entered
	Then Result of calculation is <result>

Examples: 
	| operand1 | operand2 | result |
	| 7        | 3        | 4      |
	| -10      | 10       | -20    |
	| 0,75     | 0,5      | 0,25   |
	| -100     | -2       | -98    |

@Mult
@Smoke
Scenario Outline: Calculator - Check Mult
	Given I provide number <operand1> into calculator
	And I provide number <operand2> into calculator
	When I get 'Mult' of numbers entered
	Then Result of calculation is <result>

Examples: 
	| operand1 | operand2 | result |
	| 2        | 5        | 10     |
	| -5       | 10       | -50    |
	| 0,5      | 0,5      | 0,25   |
	| -100     | -2       | 200    |


@Div
@Smoke
Scenario Outline: Calculator - Check Div
	Given I provide number <operand1> into calculator
	And I provide number <operand2> into calculator
	When I get 'Div' of numbers entered
	Then Result of calculation is <result>

Examples: 
	| operand1 | operand2 | result |
	| 10       | 5        | 2      |
	| -10      | 2        | -5     |
	| 0,25     | 0,5      | 0,5    |
	| -100     | -2       | 50     |

@Div
@CriticalPath
Scenario Outline: Calculator - Check Div1
	Given I provide number 10 into calculator
	And I provide number 2 into calculator
	When I get 'Div' of numbers entered
	And I remember the result of calculation

	Given I provide number 20 into calculator
	And I provide number 10 into calculator
	When I get 'Div' of numbers entered
	And I remember the result of calculation

	Then I check that collection of results contains 2 items