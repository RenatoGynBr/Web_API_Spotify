using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Spotify.Models
{
    [Table("VendaItem")]
    public class VendaItem
    {
        [Key]
        public int VendaItemId { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public Venda Venda { get; set; }
        public int VendaId { get; set; }
    }
}
