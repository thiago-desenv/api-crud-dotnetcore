using System;
using Api.Domain.DTOS.County;

namespace Api.Domain.DTOS.CEP
{
    public class CepDTO
    {
        public Guid Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid CountyID { get; set; }
        public CountyDTOComplete County { get; set; }
    }
}
