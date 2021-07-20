using System;
using Api.Domain.DTOS.UF;

namespace Api.Domain.DTOS.County
{
    public class CountyDTOComplete
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CodIBGE { get; set; }
        public Guid UFId { get; set; }
        public UfDTO UF { get; set; }
    }
}
