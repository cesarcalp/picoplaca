using System;
using System.ComponentModel.DataAnnotations;

namespace PicoPlaca.ViewModel
{
    public class VerificatorViewModel
    {
        [Display(Name = "Plate Number")]
        [Required]
        [StringLength(7, MinimumLength = 7)]
        public string PlateNumber { set; get; }

        [Display(Name = "Date")]
        [Required]
        public DateTime Date { set; get; }

        [Display(Name = "Time")]
        [Required]
        public TimeSpan Time { set; get; }
    }
}
