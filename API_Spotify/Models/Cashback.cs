using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API_Spotify.Models
{
    [Table("Cashback")]
    public partial class Cashback
    {
        [Key]
        public int CashbackId { get; set; }
        public int GeneroId { get; set; }

        [Range(1, 7)]

        public int DiaSemana { get; set; }

        [Range(1, 99)]
        public decimal Percentual { get; set; }
    }
}
