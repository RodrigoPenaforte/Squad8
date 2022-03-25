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
        [DisplayName("Nome/apelido")]
        public string apelido { get; set; }

         [Required]
         [DisplayName("Telefone")]
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