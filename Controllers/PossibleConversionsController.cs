using CurrConverter.Models.PossibleConversions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CurrConverter.Controllers
{
    public class PossibleConversions : ControllerBase
    {
        // [ProducesResponseType(typeof(CurrencyConvertor), StatusCodes.Status200OK)]
        [HttpGet("PossibleConversions")]
        public IActionResult Get([Required] PossibleConversionsRequest currencyConversionRequest)
        {
            PossibleConversionsProvider outputCurrencyAndAmountProvider = new PossibleConversionsProvider();
            return Ok(outputCurrencyAndAmountProvider.PrintAllPossibleConversions(currencyConversionRequest));
        }
    }
}