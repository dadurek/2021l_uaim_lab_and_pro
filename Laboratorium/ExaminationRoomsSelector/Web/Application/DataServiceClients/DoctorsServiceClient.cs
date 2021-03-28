namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Dtos;
    using Web.Application;

    public class DoctorsServiceClient : IDoctorsServiceClient
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly Config config;

        public DoctorsServiceClient(IHttpClientFactory clientFactory, Config config)
        {
            this.clientFactory = clientFactory;
            this.config = config;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var url = config.DoctorUrl + "doctors";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<DoctorDto>>(responseStream, options);
        }

        public async void AddDoctor(DoctorDto doctorDto)
        {
            var jsonString = JsonSerializer.Serialize(doctorDto);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var client = clientFactory.CreateClient();

            var url = config.DoctorUrl + "add-doctor";

            var result = client.PostAsync(url, content).Result;
        }
    }
}