using Dapper;
using Microsoft.Data.SqlClient;
using System;

namespace CurrConverter.Models.Trades
{
    public class TradesRepository
    {

        private readonly string _connectionString;
        public TradesRepository(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _connectionString = connectionString;
        }


        public void Insert(Trade trade)
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var sql = "INSERT into [Trades] (Client, FromCurrency, ToCurrency, FromAmount, Rate, ConvertedAmount, Timestamp) values(@MyClient, @FromCurrency, @ToCurrency, @FromAmount, @Rate, @ConvertedAmount, @Timestamp) ";
            sqlConnection.Execute(sql, new
            {
                MyClient = trade.Client,
                FromCurrency = trade.FromCurrency,
                ToCurrency = trade.ToCurrency,
                FromAmount = trade.FromAmount,
                Rate = trade.Rate,
                ConvertedAmount = trade.ConvertedAmount,
                TimeStamp = DateTime.UtcNow
            });
        }

    }
}
