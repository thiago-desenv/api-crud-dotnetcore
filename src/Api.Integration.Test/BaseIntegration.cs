using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.DTOS;
using application;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Api.Integration.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext myContext { get; private set; }
        public HttpClient Client { get; private set; }
        public IMapper mapper { get; set; }
        public string HostApi { get; set; }
        public HttpResponseMessage Response { get; set; }

        public BaseIntegration()
        {
            HostApi = "http://localhost:5000/api/";
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();
            var server = new TestServer(builder);

            myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();

            mapper = new AutoMapperFixture().GetMapper();
            Client = server.CreateClient();
        }

        public async Task AddToken()
        {
            var loginDTO = new LoginDTO() { Email = "administrator@hotmail.com" };

            var resultLogin = await PostJsonAsync(loginDTO, $"{HostApi}login", Client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResponseDTO>(jsonLogin);

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                                                loginObject.accessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client)
        {
            return await client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(dataclass),
                    Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            myContext.Dispose();
            Client.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DTOToModelProfile());
                cfg.AddProfile(new EntityToDTOProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose()
        {
        }
    }
}
