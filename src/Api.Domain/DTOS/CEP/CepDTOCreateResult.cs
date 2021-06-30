using System;

namespace Api.Domain.DTOS.CEP
{
    public class CepDTOCreateResult
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid CountyId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
