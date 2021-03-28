﻿namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
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
        private IHttpClientFactory clientFactory;

        public DoctorsServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var url = Config.DOCTOR_URL + "doctors";

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

            var url = Config.DOCTOR_URL + "add-doctor";

            var result = client.PostAsync(url, content).Result;
        }
    }
}