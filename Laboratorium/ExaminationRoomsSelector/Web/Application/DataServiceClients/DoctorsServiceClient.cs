namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    using ExaminationRoomsSelector.Web.Application.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    
    public class DoctorsServiceClient : IDoctorsServiceClient
    {
        public IHttpClientFactory clientFactory;
        public DoctorsServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://localhost:8082/doctors");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<DoctorDto>>(responseStream, options);
        }
        
        public async void AddDoctor(DoctorDto doctorDto)
        {
            string jsonString = JsonSerializer.Serialize(doctorDto);

            var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            
            var client = clientFactory.CreateClient();

            var result = client.PostAsync("http://localhost:8082/add-doctor", content).Result;
            
            
        }
        
        
    }
}

