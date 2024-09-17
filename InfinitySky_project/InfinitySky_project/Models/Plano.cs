using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InfinitySky_project.Models
{
    public class Plano
    {

        //adicionando todos os campos igualmente no banco de dados 


        [Key]
        public int IdPlano { get; set; }

        [Required]
        public string HospedagemPlano { get; set; }

        [Required]
        public string CursoPlano { get; set; }

        [Required]
        public string InstituicaoPlano { get; set; }

        [Required]
        public string PeriodoPlano { get; set; }

        [Required]
        public string DescricaoPlano { get; set; }

        public string ImagemPlano { get; set; }

        public decimal Valor { get; set; }  // Novo campo

        [ForeignKey("Pais")]
        public int IdPais { get; set; }

        public virtual Pais Pais { get; set; }
    }
}
