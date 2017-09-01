using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PicoPlaca.Transversal
{
    public class CustomFormatProvider
    {
        private static CultureInfo m_proveedorFormato
        {
            get
            {
                var cultura = new CultureInfo("es-EC");

                cultura.NumberFormat.NumberDecimalDigits = 2;
                cultura.NumberFormat.NumberDecimalSeparator = ".";
                cultura.NumberFormat.NumberGroupSeparator = ",";
                cultura.NumberFormat.NumberGroupSizes = new int[] { 3 };
                cultura.NumberFormat.NumberNegativePattern = 1;

                cultura.NumberFormat.CurrencyDecimalDigits = 2;
                cultura.NumberFormat.CurrencyDecimalSeparator = ".";
                cultura.NumberFormat.CurrencyGroupSeparator = ",";
                cultura.NumberFormat.CurrencyGroupSizes = new int[] { 3 };
                cultura.NumberFormat.CurrencyNegativePattern = 1;
                cultura.NumberFormat.CurrencyPositivePattern = 0;
                cultura.NumberFormat.CurrencySymbol = "$";

                cultura.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                return cultura;
            }
        }
        public static string ShortDatePattern
        {
            get
            {
                return "dd/MM/yyyy";
            }
        }
        public static string ShortTimePattern
        {
            get
            {
                return "HH:mm:ss";
            }
        }
        public static IFormatProvider ProveedorFormato
        {
            get
            {
                return (IFormatProvider)m_proveedorFormato.Clone();
            }
        }
    }
}
