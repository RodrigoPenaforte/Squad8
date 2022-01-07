using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mulher_Presente.Models
{
    public class Parceiros
    {
        [Key]
        [Required]
        public int id_parceiro {get; set;}

        [Required]
        [DisplayName("Especialidade")]
        public string Especilidade {get;set;}

         [Required]
        public string Nome {get;set;}

         [Required]
        public string Telefone {get;set;}

         [Required]
         [DisplayName("E-mail")]
        public string email {get;set;}

        


    }
}