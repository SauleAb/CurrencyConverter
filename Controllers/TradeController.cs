using CurrConverter.Models;
using CurrConverter.Models.Trades;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CurrConverter.Controllers
{
    public class TradeController : Controller
    {
        [HttpPost("NewTrade")]
        public IActionResult Post([Required][FromBody] AmountConversionRequest amountConversionRequest)
        {
            TradesRepository tradesRepository = new TradesRepository("Server=localhost;Database=TestCurrencyConverter;Trusted_Connection=True;TrustServerCertificate=true;");

            AmountConversion amountConversion = new AmountConversion();
            Trade trade = new Trade
            {
                FromAmount = amountConversionRequest.FromAmount,
                ToCurrency = amountConversionRequest.ToCurrency,
                FromCurrency = amountConversionRequest.FromCurrency,
                Client = amountConversionRequest.Client,
                Rate = amountConversion.GetCurrencyCombinationRate(amountConversionRequest),
                ConvertedAmount = amountConversion.AmountConvertor(amountConversionRequest)
            };
            tradesRepository.Insert(trade);
            return Ok();
        }
    }
}
