using System;
using Microsoft.UI.Xaml.Data;
using BarrocIntens.Models;

namespace BarrocIntens.Customer
{
    public class TotalPriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Ensure the input is not null and is of the expected type
            if (value is ContractProduct product)
            {
                // Calculate and return the total price
                return (product.Amount * product.LeassedPrice).ToString("F2"); // Formats as 2 decimal places
            }
            return "0.00"; // Fallback if value is null or not of the expected type
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}
