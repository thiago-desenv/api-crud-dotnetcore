using System;

namespace Api.Domain.DTOS.User
{
    public class UserDTOUpdateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
