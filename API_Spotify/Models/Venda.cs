using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Spotify.Models
{
    [Table("Venda")]
    public class Venda
    {
        public Venda()
        {
            VendaItens = new Collection<VendaItem>();
        }
        [Key]
        public int VendaId { get; set; }
        public DateTime DataVenda { get; set; }
        public string NomeCliente { get; set; }
        public decimal TotalVenda { get; set; }
        public decimal TotalCashback { get; set; }
        public ICollection<VendaItem> VendaItens { get; set; } 
    }
}
