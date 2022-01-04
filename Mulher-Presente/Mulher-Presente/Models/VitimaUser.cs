using System.ComponentModel.DataAnnotations;

namespace Mulher_Presente.Models
{
    public class VitimaUser
    {
        [Key]
        [Required]
        public string ID_vitima { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Telefone { get; set; }
        [Required]

        public string Email { get; set; }

        // FK edição

        [Required]

        public int ParceirosUserID_parceiro { get; set; }

        public ParceirosUser ParceirosUser { get; set; }


    } 
}