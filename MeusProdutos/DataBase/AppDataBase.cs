using MeusProdutos.Model;
using MeusProdutos.Services;
using Microsoft.EntityFrameworkCore;

namespace MeusProdutos.DataBase
{
    public class AppDataBase : DbContext
    {
        public AppDataBase(DbContextOptions<AppDataBase> options) : base(options)
        {
        }

        //Definindo as listas de Classes para tabelas do banco de dados
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Regras para ID do PRODUTO
            modelBuilder.Entity<Produto>().Property(produto => produto.Id).ValueGeneratedOnAdd();
            //Regras para NOME do PRODUTO
            modelBuilder.Entity<Produto>().Property(produto => produto.Nome).IsRequired();
            //Regras para VALOR do PRODUTO
            modelBuilder.Entity<Produto>().Property(produto => produto.Valor).IsRequired();
            //Regras para STATUS do PRODUTO
            modelBuilder.Entity<Produto>().Property(produto => produto.Status).IsRequired();

            //Regras para ID do USUARIO
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Id).ValueGeneratedOnAdd();
            //Regras para NOME do USUARIO
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Nome).IsRequired();
            //Regras para SENHA do USUARIO
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Senha).IsRequired();
            //Regras para EMAIL do USUARIO
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Email).IsRequired();
            modelBuilder.Entity<Usuario>().HasIndex(e => e.Email).IsUnique();


            //Populando o banco de dados para visualização de teste
            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, Nome = "PenDrive 64gb", Valor = 79.99f, Status = true},
                new Produto { Id = 2, Nome = "Cabo USB tipo C", Valor = 12.99f, Status = true},
                new Produto { Id = 3, Nome = "GeForce RTX 3200", Valor = 8999.99f, Status = false});

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nome = "admin", Senha = EncryptService.Encrypt("12345678"), Email = "admin@admin.com"},
                new Usuario { Id = 2, Nome = "Usuario1", Senha = EncryptService.Encrypt("12345678"), Email = "usuario1@hotmail.com" },
                new Usuario { Id = 3, Nome = "Usuario2", Senha = EncryptService.Encrypt("87654321"), Email = "usuario2@gmail.com" },
                new Usuario { Id = 4, Nome = "Usuario3", Senha = EncryptService.Encrypt("14725800"), Email = "usuario3@teste.com" });
        }

    }
}
