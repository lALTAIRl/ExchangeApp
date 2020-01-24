using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exchange_App.DAL.Entities
{
    public class Currency
    {
        public int Id { get; set; }

        [Required]
        public string CurrencyName { get; set; }

        [Required]
        [Range(1, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double PurchasePrice { get; set; }

        [Required]
        [Range(1, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double SellingPrice { get; set; }
    }
}
