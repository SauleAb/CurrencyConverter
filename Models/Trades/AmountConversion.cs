namespace CurrConverter.Models.Trades
{
    public class AmountConversion
    {
        public AmountConversion()
        {
        }

        public decimal GetCurrencyCombinationRate (AmountConversionRequest amountConversionRequest)
        {
            CurrencyRateProvider currencyRateProvider = new CurrencyRateProvider();
            CurrencyProvider currencyProvider = new CurrencyProvider();
            string currencyCombination = amountConversionRequest.FromCurrency + amountConversionRequest.ToCurrency;
            decimal convertedAmount;
            decimal value;
            currencyRateProvider.currencyCombinationsAndRates.TryGetValue(currencyCombination, out value);
            return value;
        }

        public decimal AmountConvertor(AmountConversionRequest amountConversionRequest)
        {
            CurrencyRateProvider currencyRateProvider = new CurrencyRateProvider();
            CurrencyProvider currencyProvider = new CurrencyProvider();
            decimal convertedAmount;
            if (currencyProvider.currencyList.Contains(amountConversionRequest.FromCurrency) && currencyProvider.currencyList.Contains(amountConversionRequest.ToCurrency))
            {
                string currencyCombination = amountConversionRequest.FromCurrency + amountConversionRequest.ToCurrency;
                string reverseStringCombination = amountConversionRequest.ToCurrency + amountConversionRequest.FromCurrency;
                currencyRateProvider.currencyCombinationsAndRates.TryGetValue(currencyCombination, out decimal value);
                convertedAmount = value * amountConversionRequest.FromAmount;
                if (!currencyRateProvider.currencyCombinationsAndRates.ContainsKey(currencyCombination) && currencyRateProvider.currencyCombinationsAndRates.ContainsKey(reverseStringCombination))
                {
                    currencyRateProvider.currencyCombinationsAndRates.TryGetValue(reverseStringCombination, out value);
                    value = 1 / value;
                    convertedAmount = value * amountConversionRequest.FromAmount;
                }
                return convertedAmount;
            }
            return 0m;
        }
    }
}
