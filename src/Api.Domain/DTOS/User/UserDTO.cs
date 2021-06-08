using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOS.User
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "E=mail em formato inválido")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}
