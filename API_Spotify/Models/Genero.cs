using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Spotify.Models
{
    [Table("Genero")]
    public class Genero
    {
        public Genero()
        {
            Albuns = new Collection<Album>();
        }

        [Key]
        public int GeneroId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        public ICollection<Album> Albuns { get; set; } // Propriedade de Navegação
    }
}
