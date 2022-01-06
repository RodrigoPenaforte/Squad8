using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mulher_Presente.Models
{
    public class Vitima
    {
        [Key]
        [Required]
        public int id_vitima {get; set;}

        [Required]
        [DisplayName("Nome fictício ou um apelido")]
        public string apelido { get; set; }

         [Required]
         [DisplayName("Numero de Contato")]
        public string telefone { get; set; }

         [Required]
         [DisplayName("E-mail")]
        public string email { get; set; }

        [Required]
        [DisplayName("Especilidades")]
        public int Parceirosid_parceiro{get;set;}
        public Parceiros Parceiros{get;set;}
        

    }
}