using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOS.CEP
{
    public class CepDTOUpdate
    {
        [Required(ErrorMessage = "Id é um campo obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "CEP é um campo obrigatório")]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        [Required(ErrorMessage = "Município é um campo obrigatório")]
        public Guid CountyId { get; set; }
    }
}
