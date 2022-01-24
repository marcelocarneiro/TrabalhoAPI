using System;
using System.ComponentModel.DataAnnotations;

namespace DevIo.Api.ViewModels
{
    public class PostViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracter")]
        public string Texto { get; set; }      

        
    }
}
