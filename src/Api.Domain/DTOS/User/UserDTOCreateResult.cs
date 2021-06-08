using System;

namespace Api.Domain.DTOS.User
{
    public class UserDTOCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
