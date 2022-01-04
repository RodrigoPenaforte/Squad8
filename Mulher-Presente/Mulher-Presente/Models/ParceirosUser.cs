using System.ComponentModel.DataAnnotations;

namespace Mulher_Presente.Models
{
    public class ParceirosUser
    {
        [Key]
        [Required]

        public string ID_parceiro { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone_parceiro { get; set; }
        [Required]
        public string Email_parceiro { get; set; }
        [Required]
        public string Especialidade { get; set; }


    }
}
