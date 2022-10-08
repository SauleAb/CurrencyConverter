

using Dapper;
using Microsoft.Data.SqlClient;

namespace CurrConverter.Models
{
    public class CurrencyRateProvider
    {
        public Dictionary<string, decimal> currencyCombinationsAndRates = new Dictionary<string, decimal>();

        public CurrencyRateProvider()
        {
            InitCurrencyCombinationsRates();
        }
        private void InitCurrencyCombinationsRates()
        {
            var sqlConnection = new SqlConnection("Server=localhost;Database=TestCurrencyConverter;Trusted_Connection=True;TrustServerCertificate=true");
            var sql = "select CurrencyPair,Rate from CurrencyPairRates";
            var currencies = sqlConnection.Query<(string CurrencyPair, decimal Rate)>(sql);
            foreach (var currencyPairRate in currencies)
            {
                currencyCombinationsAndRates.Add(currencyPairRate.CurrencyPair, currencyPairRate.Rate);
            }
        }
    }
}
