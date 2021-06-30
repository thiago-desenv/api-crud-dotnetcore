using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOS.CEP
{
    public class CepDTOCreate
    {
        [Required(ErrorMessage = "CEP é um campo obrigatório")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Logradouro é um campo obrigatório")]
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        [Required(ErrorMessage = "Município é um campo obrigatório")]
        public Guid CountyID { get; set; }
    }
}
