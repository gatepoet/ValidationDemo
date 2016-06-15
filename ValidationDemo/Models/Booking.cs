using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ValidationDemo.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [Uppercase(ErrorMessage = "Fra-sted må være store bokstaver")]
        public string From { get; set; }

        [Required]
        [Uppercase]
        [DisplayName("Til")]
        [NotEqualTo(nameof(From))]
        public string To { get; set; }

        [DataType(DataType.Date)]
        public DateTime Leaving { get; set; }

        [DataType(DataType.Date)]
        public DateTime Returning { get; set; }
    }
}