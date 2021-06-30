using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOS.County
{
    public class CountyDTOCreate
    {
        [Required(ErrorMessage = "O município é obrigatório")]
        [StringLength(60, ErrorMessage = "Nome do município deve ter no máximo {1} caracateres")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE inválido")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código da UF é um campo obrigatório")]
        public Guid UFId { get; set; }
    }
}
