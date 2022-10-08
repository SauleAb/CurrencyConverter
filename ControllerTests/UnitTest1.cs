using CurrConverter.Models;
using CurrConverter.Models.PossibleConversions;

namespace ControllerTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void GetConvertedAmountForReverseCurrency_ForJpyEur_ReturnsCorrenctAmount()
        {
            PossibleConversionsProvider outputCurrencyAndAmountProvider = new PossibleConversionsProvider();
            var fromCurrency = "jpy";
            var fromAmount = 100;
            var expectedoutputCurrencyAndAmount = "eur: 0,72";
            var input = new PossibleConversionsRequest() { FromCurrency = fromCurrency, FromAmount=fromAmount};

            var outputCurrencyAndAmount = outputCurrencyAndAmountProvider.PrintAllPossibleConversions(input);
        
            StringAssert.Contains(expectedoutputCurrencyAndAmount, outputCurrencyAndAmount);
        }

        [Test]
        public void CurrencyRequest_ReturnsMoreThanOneConversion()
        {
            PossibleConversionsProvider outputCurrencyAndAmountProvider = new PossibleConversionsProvider();
            var fromCurrency = "jpy";
            var fromAmount = 100;

            var input = new PossibleConversionsRequest() { FromCurrency = fromCurrency, FromAmount = fromAmount };

            var outputCurrencyAndAmount = outputCurrencyAndAmountProvider.PrintAllPossibleConversions(input);

            Assert.Greater(outputCurrencyAndAmount.Count(ch => ch == '\n'), 1);
        }



        [Test]
        public void GetErrorMessage_ForCurrencyAsd_ReturnsErrorMessage()
        {
            PossibleConversionsProvider outputCurrencyAndAmountProvider = new PossibleConversionsProvider();
            var fromCurrency = "asd";
            var fromAmount = 100;
            var expectedErrorMessage = "Please enter a valid currency";
            var input = new PossibleConversionsRequest() { FromCurrency = fromCurrency, FromAmount = fromAmount };

            var outputErrorMessage = outputCurrencyAndAmountProvider.PrintAllPossibleConversions(input);

            StringAssert.Contains(expectedErrorMessage, outputErrorMessage);

        }


        [Test]
        public void GetErrorMessage_ForMoreThanThreeCharCurrency_ReturnsErrorMessage()
        {
            //Arranage
            PossibleConversionsProvider outputCurrencyAndAmountProvider = new PossibleConversionsProvider();
            var fromCurrency = "asdf";
            var fromAmount = 100;
            var expectedErrorMessage = "Please enter a valid currency";
            var input = new PossibleConversionsRequest() { FromCurrency = fromCurrency, FromAmount = fromAmount };

            //Act
            var outputErrorMessage = outputCurrencyAndAmountProvider.PrintAllPossibleConversions(input);

            //Assert
            Assert.AreEqual(expectedErrorMessage, outputErrorMessage);
        }
    }
}