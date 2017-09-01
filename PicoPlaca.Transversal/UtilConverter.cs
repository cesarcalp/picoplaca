using System;
using System.Globalization;

namespace PicoPlaca.Transversal
{
    public static class UtilConverter
    {
        public static DateTime ConvertToDate(string value)
        {
            DateTime dt;
            if (DateTime.TryParseExact(value,
                                        "d/M/yyyy",
                                        CustomFormatProvider.ProveedorFormato, 
                                        DateTimeStyles.None,
                out dt))
            {
                return dt;
            }
            return dt;

        }

        public static TimeSpan ConvertToTime(string value)
        {
            DateTime dt;
            if (!DateTime.TryParseExact(value, "HH:mm:ss", CustomFormatProvider.ProveedorFormato,
                                                          DateTimeStyles.None, out dt))
            {
                return dt.TimeOfDay;
            }
            return dt.TimeOfDay;
        }
    }
}
