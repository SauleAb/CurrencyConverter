using CurrConverter.Models.PossibleConversions;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CurrConverter.Models
{
    public class CurrencyProvider
    {
        public List<string> currencyList = new List<string>();

        public CurrencyProvider()
        {
            InitCurrencies();
        }

        private void InitCurrencies()
        {
            var sqlConnection = new SqlConnection("Server=localhost;Database=TestCurrencyConverter;Trusted_Connection=True;TrustServerCertificate=true;");
            var sql = "select Currency from Currencies";
            var currencies = sqlConnection.Query<string>(sql);
            foreach (var currency in currencies)
            {
                currencyList.Add(currency);
            }
        }
    }
}
