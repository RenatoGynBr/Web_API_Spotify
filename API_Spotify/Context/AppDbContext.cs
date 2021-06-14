using API_Spotify.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Spotify.Context
{
    public class AppDbContext : DbContext
    {
        // Cria uma sessão contexto para operações CRUD
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public AppDbContext()
        {
        }

        // Mapeamento das Entidades
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Cashback> Cashbacks { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaItem> VendaItens { get; set; }
    }
}
