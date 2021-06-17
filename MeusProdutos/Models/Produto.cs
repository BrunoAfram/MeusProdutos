using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeusProdutos.Model
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(80), MinLength(3)]
        public string Nome { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Somente valores positivos")]
        public float Valor { get; set; }
        public bool Status { get; set; }

        

    }
}
