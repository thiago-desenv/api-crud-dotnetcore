using System;

namespace Api.Domain.DTOS.County
{
    public class CountyDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CodIBGE { get; set; }
        public Guid UFId { get; set; }
    }
}
