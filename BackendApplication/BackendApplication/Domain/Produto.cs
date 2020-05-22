using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendApplication.Domain
{
    /*[Table("Produto")]*/
    public class Produto
    {
        /* inteiro nullable, pode ser um número ou null */
        /*[Key]
        [Column(name: "Codigo")]*/
        public int? Codigo { get; set; }

        /*[Column(name: "Nome")]
        [Required]
        [MaxLength(50)]*/
        public string Nome { get; set; }

        /*[Column(name: "Preco")]*/
        public double Preco { get; set; }

        /*[Column(name: "Avaliacao")]*/
        public int Avaliacao { get; set; }

        /*[Column(name: "ImagemUrl")]*/
        public string ImagemUrl { get; set; }
    }
}
