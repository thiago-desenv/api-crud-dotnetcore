using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOS.County
{
    public class CountyDTOUpdate
    {
        [Required(ErrorMessage = "O campo ID é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Município é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "O campo município deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE inválido")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é um campo obrigatório")]
        public Guid UFId { get; set; }
    }
}
