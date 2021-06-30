using System;

namespace Api.Domain.DTOS.County
{
    public class CountyDTOUpdateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid CodIBGE { get; set; }
        public Guid UFId { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
