using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Spotify.Models
{
    [Table("Album")]
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Titulo { get; set; }

        [Required]
        [Range(1, 9999)]
        public decimal Preco { get; set; }

        public Genero Genero { get; set; }
        public int GeneroId { get; set; }
    }
}
