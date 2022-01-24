using System;
using System.ComponentModel.DataAnnotations;

namespace DevIo.Api.ViewModels
{
    public class IntegranteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracter")]
        public string Nome { get; set; }      

        
    }
}
