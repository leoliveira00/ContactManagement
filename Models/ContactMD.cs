using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Models
{
    public class ContactMD
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(9999, MinimumLength = 5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O contato é obrigatório", AllowEmptyStrings = false)]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O contato deve ter 9 caracteres.")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }
    }
}
