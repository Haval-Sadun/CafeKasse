using CafeKasse.MAUI.Models;
using CafeKasse.MAUI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Converter
{
    class StatusToColorConverter : IValueConverter
    {
        [Obsolete]
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is TableStatus status)
            {
                switch (status)
                {
                    case TableStatus.Resevered:
                        return Color.FromHex("FAEED1"); // yallow 
                    case TableStatus.Available:
                        return Color.FromHex("B2C8BA"); // Green
                    case TableStatus.Occupied:
                        return Color.FromHex("FF6C22"); // Red
                }
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
