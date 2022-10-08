﻿using System.ComponentModel.DataAnnotations;

namespace CurrConverter.Models.PossibleConversions
{
    public class PossibleConversionsRequest
    {
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string FromCurrency { get; set; }

        [Required]
        [Range(0.01, 99999999999999)]
        public decimal FromAmount { get; set; }
    }
}
