using System;

namespace Api.Domain.DTOS.County
{
    public class CountyDTOUpdateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CodIBGE { get; set; }
        public Guid UFId { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
