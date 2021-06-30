using System;

namespace Api.Domain.DTOS.County
{
    public class CountyDTOCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UFId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
