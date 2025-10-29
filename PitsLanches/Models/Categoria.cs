using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PitsLanches.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Display(Name ="Nome")]
        [Required(ErrorMessage =("Informe o {0} da categoria"))]
        [StringLength(100,ErrorMessage ="{0} maximo de 100 caracteres")]
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho maximo e 200 caracteres")]
        [Required(ErrorMessage = ("Informe a descricao da categoria"))]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }
    }
}
