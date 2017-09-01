using System;
using System.Collections.Generic;
using System.Text;

namespace PicoPlaca.Transversal
{
    public static class DateTimeExtensions
    {
        public static DateTime Now()
        {
            var fechaActual = DateTime.Now;
            var currentTimeZone = TimeZoneInfo.Local;
            var pacificZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            return TimeZoneInfo.ConvertTime(fechaActual, currentTimeZone, pacificZone);
        }
    }
}
