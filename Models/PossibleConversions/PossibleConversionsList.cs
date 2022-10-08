using System.Text;

namespace CurrConverter.Models.PossibleConversions
{
    public class PossibleConversionsList
    {
        public PossibleConversionsList()
        {

        }

        public List<string> ToCurrencyList = new List<string>();
        public List<string> CurrencyCombinations = new List<string>();
        public void GetCurrencyCombinations(PossibleConversionsRequest possibleConversionsRequest)
        {
            CurrencyProvider currencyProvider = new CurrencyProvider();
            foreach (var toCurrency in currencyProvider.currencyList)
            {
                string currencyCombination = possibleConversionsRequest.FromCurrency + toCurrency;
                CurrencyCombinations.Add(currencyCombination);
                ToCurrencyList.Add(toCurrency);
            }
        }

        public decimal GetConvertedAmount(PossibleConversionsRequest possibleConversionsRequest)
        {
            PossibleConversionsList possibleConversionsList = new PossibleConversionsList();
            CurrencyRateProvider currencyRateProvider = new CurrencyRateProvider();
            foreach (var currencyCombination in possibleConversionsList.CurrencyCombinations)
            {
                currencyRateProvider.currencyCombinationsAndRates.TryGetValue(currencyCombination, out decimal value);
                decimal convertedAmount = value * possibleConversionsRequest.FromAmount;
                return convertedAmount;
            }
            return 0m;
        }
    }
}