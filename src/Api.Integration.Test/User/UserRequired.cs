using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

        public UserRequired()
        {
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();
        }

        [Fact(DisplayName = "Teste usuário")]
        public async Task Realiza_Teste_CRUD_Usuario()
        {
            await AddToken();

            var userDTO = new UserDTOCreate() { Name = _name, Email = _email };

            var response = await PostJsonAsync(userDTO, $"{HostApi}users", Client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<UserDTOCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(registroPost.Name, userDTO.Name);
            Assert.Equal(registroPost.Email, userDTO.Email);
            Assert.False(registroPost.Id == default(Guid));
        }

        [Fact(DisplayName = "Teste método GetAll")]
        public async Task Realiza_Teste_GetAll()
        {
            await AddToken();

            var response = await Client.GetAsync($"{HostApi}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var lsFromJson = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(jsonResult);
            Assert.NotNull(lsFromJson);
            Assert.True(lsFromJson.Count() > 0);
        }

        [Fact(DisplayName = "Teste método PUT")]
        public async Task Realiza_Teste_Metodo_PUT()
        {
            await AddToken();

            string idGuidMock = "E5B0E755-91C7-43E1-9053-422F0FA828D6";
            var responseGet = await Client.GetAsync($"{HostApi}users/{idGuidMock}");
            var strResponseGet = await responseGet.Content.ReadAsStringAsync();
            var convertGetFromUserDTO = JsonConvert.DeserializeObject<UserDTO>(strResponseGet);

            var user = new UserDTOUpdate()
            {
                Id = convertGetFromUserDTO.Id,
                Name = "Thiago Xavier Ferreira",
                Email = "thiago@hotmail.com"
            };

            var jsonUser = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var responsePut = await Client.PutAsync($"{HostApi}users", jsonUser);
            var strResponsePut = await responsePut.Content.ReadAsStringAsync();

            var registerUpdated = JsonConvert.DeserializeObject<UserDTOUpdateResult>(strResponsePut);
            Assert.True(responsePut.StatusCode == HttpStatusCode.OK);
            Assert.NotNull(registerUpdated);
            Assert.Equal(registerUpdated.Id, user.Id);
            Assert.Equal(registerUpdated.Name, user.Name);
            Assert.Equal(registerUpdated.Email, user.Email);
        }

        [Fact(DisplayName = "Testa método Get")]
        public async Task Realiza_Teste_Metodo_Get()
        {
            await AddToken();

            Guid idGuidMock = Guid.Parse("E5B0E755-91C7-43E1-9053-422F0FA828D6");
            var responseGet = await Client.GetAsync($"{HostApi}users/{idGuidMock}");
            var strResponseGet = await responseGet.Content.ReadAsStringAsync();

            var returnGet = JsonConvert.DeserializeObject<UserDTO>(strResponseGet);
            Assert.True(responseGet.StatusCode == HttpStatusCode.OK);
            Assert.Equal(returnGet.Id, idGuidMock);
            Assert.Equal(returnGet.Name, "Thiago Xavier Ferreira");
            Assert.Equal(returnGet.Email, "thiago@hotmail.com");
        }

        [Fact(DisplayName = "Teste método Delete")]
        public async Task Realiza_Teste_Metodo_Delete()
        {
            await AddToken();

            Guid idGuidMock = Guid.Parse("2F46AA59-3098-4336-AB15-A0FFBE05A720");
            var responseDelete = await Client.DeleteAsync($"{HostApi}users/{idGuidMock}");
            Assert.True(responseDelete.StatusCode == HttpStatusCode.OK);
            var strResponseDelete = await responseDelete.Content.ReadAsStringAsync();
            bool blResponseDelete = Convert.ToBoolean(strResponseDelete);
            Assert.True(blResponseDelete);
        }
    }
}
