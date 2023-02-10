using Epam.TAF.Core.ContextHelper;
using Epam.TAF.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps
{
    [Binding]
    public class CalculatorSteps
    {
        private Calculator Calculator = new();

        [StepDefinition(@"I provide number (.*) into calculator")]
        public void GivenIProvideNumberIntoCalculator(double operand)
        {
            Calculator.EnterOperand(operand);
        }

        #region Operations

        [When(@"I get Sum of numbers entered")]
        public void WhenIGetSumOfNumbersEntered()
        {
            Calculator.Sum();
        }

        [When(@"I get Diff of numbers entered")]
        public void WhenIGetDiffOfNumbersEntered()
        {
            Calculator.Diff();
        }

        [When(@"I get Mult of numbers entered")]
        public void WhenIGetMultOfNumbersEntered()
        {
            Calculator.Mult();
        }

        [When(@"I get Div of numbers entered")]
        public void WhenIGetDivOfNumbersEntered()
        {
            Calculator.Div();
        }

        [When(@"I get '(Sum|Diff|Mult|Div)' of numbers entered")]
        public void WhenIGetOfNumbersEntered(Operation operation)
        {
            switch (operation)
            {
                case Operation.Sum: WhenIGetSumOfNumbersEntered(); break;
                case Operation.Diff: WhenIGetDiffOfNumbersEntered(); break;
                case Operation.Mult: WhenIGetMultOfNumbersEntered(); break;
                case Operation.Div: WhenIGetDivOfNumbersEntered(); break;
            }
        }


        #endregion

        [Then(@"Result of calculation is (.*)")]
        public void ThenResultOfCalculationIs(double expectedResult)
        {
            Assert.That(Calculator.Result, Is.EqualTo(expectedResult), $"Invalid calculation result {Calculator.Result}");
        }

        [When(@"I remember the result of calculation")]
        public void WhenIRememberTheResultOfCalculation()
        {
            var contextVar = ContextVariables.CalculationResults;
            if (!ContextVariableHelper.isValueExist(contextVar))
                ContextVariableHelper.SetValueToContext(contextVar, new List<double>());

                var actualResult = ContextVariableHelper.GetValueFromContext<List<double>>(contextVar);
                actualResult.Add(Calculator.Result);
        }

        [Then(@"I check that collection of results contains (.*) items")]
        public void ThenICheckThatCollectionOfResultsContainsItems(int expectedNumberOfItems)
        {
            var contextVar = ContextVariables.CalculationResults;

            var resultList = ContextVariableHelper.GetValueFromContext<List<double>>(contextVar);

            Assert.That(resultList, Has.Count.EqualTo(expectedNumberOfItems), "Invalid number of results present.");
        }
    }

    public enum Operation
    {
        Sum,
        Diff,
        Mult,
        Div,
    }
}
