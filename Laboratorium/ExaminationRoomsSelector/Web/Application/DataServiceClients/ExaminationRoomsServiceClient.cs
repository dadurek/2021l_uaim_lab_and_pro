namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Dtos;
    using Web.Application;

    public class ExaminationRoomsServiceClient : IExaminationRoomsServiceClient
    {
        private IHttpClientFactory clientFactory;

        public ExaminationRoomsServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IEnumerable<ExaminationRoomDto>> GetAllExaminationRoomsAsync()
        {
            var url = Config.ROOM_URL + "examination-rooms";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<ExaminationRoomDto>>(responseStream, options);
        }

        public void AddRoom(ExaminationRoomDto examinationRoomDto)
        {
            var jsonString = JsonSerializer.Serialize(examinationRoomDto);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var client = clientFactory.CreateClient();

            var url = Config.ROOM_URL + "add-room";

            var result = client.PostAsync(url, content).Result;
        }
    }
}