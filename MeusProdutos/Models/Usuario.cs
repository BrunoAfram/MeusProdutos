using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MeusProdutos.Model
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(20), MinLength(3)]
        public string Nome { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(20), MinLength(8)]
        public string Senha { get; set; }

    }
}
