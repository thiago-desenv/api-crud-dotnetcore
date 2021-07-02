using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CEPEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string CEP { get; set; }

        [Required]
        [MaxLength(60)]
        public string Logradouro { get; set; }

        [MaxLength(10)]
        public string Numero { get; set; }

        [Required]
        public Guid CountyID { get; set; }

        public CountyEntity County { get; set; }
    }
}
