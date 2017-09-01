using PicoPlaca.Domain.Rules;
using PicoPlaca.Models;
using System;

namespace PicoPlaca.ManagementService.Rules
{
    public class PicoPlacaRule : IPicoPlacaRule
    {
        public bool Validate(RuleParam param)
        {
            ValidateParams(param);
            if (!ValidateWeekDays(param.Date.DayOfWeek))
                return true;

            if (!ValidatePeakHours(param.Time))
                return true;

            var lastPlateDigit = int.Parse(param.PlateNumber.Substring(param.PlateNumber.Length-1,1));
            var allowed = true;
            switch (param.Date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    if (lastPlateDigit == 1 || lastPlateDigit == 2)
                        allowed = false;
                    break;
                case DayOfWeek.Tuesday:
                    if (lastPlateDigit == 3 || lastPlateDigit == 4)
                        allowed = false;
                    break;
                case DayOfWeek.Wednesday:
                    if (lastPlateDigit == 5 || lastPlateDigit == 6)
                        allowed = false;
                    break;
                case DayOfWeek.Thursday:
                    if (lastPlateDigit == 7 || lastPlateDigit == 8)
                        allowed = false;
                    break;
                case DayOfWeek.Friday:
                    if (lastPlateDigit == 9 || lastPlateDigit == 0)
                        allowed = false;
                    break;
            }
            return allowed;
        }

        private void ValidateParams(RuleParam param)
        {
            if (param.Date == DateTime.MinValue)
                throw new ArgumentNullException("Argument required", "Date");
            if (param.Time == null)
                throw new ArgumentNullException("Argument required", "Time");
            if (string.IsNullOrWhiteSpace(param.PlateNumber))
                throw new ArgumentNullException("Argument required", "PlateNumber");
            if (param.PlateNumber.Length < 6)
                throw new ArgumentException("Argument invalid", "PlateNumber");
        }
        private bool ValidateWeekDays(DayOfWeek day)
        {
            if (day == DayOfWeek.Saturday ||
                day == DayOfWeek.Sunday)
            {
                return false;
            }
            return true;
        }

        private bool ValidatePeakHours(TimeSpan time)
        {
            var start1 = new TimeSpan(7, 0, 0); //7 o'clock
            var end1 = new TimeSpan(9, 30, 0); //9:30
            var start2 = new TimeSpan(16, 0, 0); //16 o'clock
            var end2 = new TimeSpan(19, 30, 0); //19:30
            if (!(
                (time >= start1 && time <= end1) ||
                (time >= start2 && time <= end2)
                ))
            {
                return false;
            }
            return true;
        }
    }
}
