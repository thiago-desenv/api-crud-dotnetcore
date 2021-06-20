using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTOS.User;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.User
{
    public class UserRequired : BaseIntegration
    {
        private string _name { get; set; }
        private string _email { get; set; }

        [Fact(DisplayName = "Teste usuário")]
        public async Task Realiza_Teste_CRUD_Usuario()
        {
            await AddToken();
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();

            var userDTO = new UserDTOCreate() { Name = _name, Email = _email };

            var response = await PostJsonAsync(userDTO, $"{HostApi}users", Client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<UserDTOCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(registroPost.Name, userDTO.Name);
            Assert.Equal(registroPost.Email, userDTO.Email);
            Assert.NotNull(registroPost.Id);
            Assert.False(registroPost.Id == default(Guid));
        }
    }
}
