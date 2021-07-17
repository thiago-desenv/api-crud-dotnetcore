using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class UFEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string UF { get; set; }

        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        public IEnumerable<CountyEntity> Countys { get; set; }
    }
}
