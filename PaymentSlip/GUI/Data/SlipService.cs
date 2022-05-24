using Newtonsoft.Json;
using PaymentSlip.Model;
using System.Net.Http.Headers;
using System.Text;

namespace GUI.Data
{
    public class SlipService
    {
        List<Slip> _slips = new();
        readonly HttpClient _client = new();
        private string _url = "https://localhost:7277/api/Slips/";

        public async Task<List<Slip>> SlipList()
        {
            string slips = await GetTaskAsync(_url);
            _slips = JsonConvert.DeserializeObject<List<Slip>>(slips);
            return _slips;
        }


        private async Task<string> GetTaskAsync(string path)
        {
            string response = null;
            HttpResponseMessage responseMessage = await _client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                response = await responseMessage.Content.ReadAsStringAsync();
            }
            return response;
        }

        public async void PostSlipAsync(Slip slip)
        {
            //var content = new StringContent(JsonConvert.SerializeObject(slip), Encoding.UTF8, "application/json");
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _client.PostAsync(_url, CreateRequestContent(slip)).Result;
        }

        public async void PutSlipAsync(Slip slip)
        {
            //var content = new StringContent(JsonConvert.SerializeObject(slip), Encoding.UTF8, "application/json");
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _client.PutAsync(_url + slip.Id, CreateRequestContent(slip)).Result;
        }

        public async void DeleteSlipAsync(Slip slip)
        {
            var content = new StringContent(JsonConvert.SerializeObject(slip), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _client.DeleteAsync(_url + slip.Id).Result;
        }

        private StringContent CreateRequestContent(Slip slip)
        {
            var content = new StringContent(JsonConvert.SerializeObject(slip), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}
