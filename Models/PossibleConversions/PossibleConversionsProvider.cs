using System.Text;

namespace CurrConverter.Models.PossibleConversions
{
    public class PossibleConversionsProvider
    {
        public PossibleConversionsProvider()
        {
        }

        public string PrintAllPossibleConversions(PossibleConversionsRequest possibleConversionsRequest)
        {
            CurrencyRateProvider currencyRateProvider = new CurrencyRateProvider();
            CurrencyProvider currencyProvider = new CurrencyProvider();
            PossibleConversionsList possibleConversionsList = new PossibleConversionsList();
            StringBuilder stringBuilder = new StringBuilder();
            possibleConversionsList.GetCurrencyCombinations(possibleConversionsRequest);
            string errorMessage = "Please enter a valid currency";

            if (currencyProvider.currencyList.Contains(possibleConversionsRequest.FromCurrency))
            {
                foreach (var currencyCombination in possibleConversionsList.CurrencyCombinations)
                {
                    currencyRateProvider.currencyCombinationsAndRates.TryGetValue(currencyCombination, out decimal value);
                    decimal convertedAmount = value * possibleConversionsRequest.FromAmount;
                    convertedAmount = Math.Round(convertedAmount, 2);
                    stringBuilder.Append(currencyCombination.ToString() + ": ");
                    stringBuilder.Append(possibleConversionsList.GetConvertedAmount(possibleConversionsRequest).ToString());
                    stringBuilder.Append(Environment.NewLine);
                }
            }
            else
            {
                stringBuilder.Append(errorMessage.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
