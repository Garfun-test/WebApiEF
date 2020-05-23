using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace TestBlazor.Data
{
    public class AgreementBlazorService
    {
        string baseUrl = "https://localhost:44393/";

        public async Task<Agreement[]> GetAgreementAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Agreement/GetAgreement");
            return JsonConvert.DeserializeObject<Agreement[]>(json);
        }

        public async Task<Agreement> GetAgreementByIdAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Agreement/GetAgreement/{id}");
            return JsonConvert.DeserializeObject<Agreement>(json);
        }

        public async Task<HttpResponseMessage> InsertAgreementAsync(Agreement agreement)
        {
            var load = new HttpClient();
            return await load.PostAsync($"{baseUrl}api/Agreement/AddAgreement", getStringContentFromObject(agreement));
        }

        public async Task<HttpResponseMessage> UpdateAgreementAsync(string id, Agreement agreement)
        {
            var load = new HttpClient();
            return await load.PutAsync($"{baseUrl}api/Agreement/UpdateAgreement/{id}", getStringContentFromObject(agreement));
        }

        public async Task<HttpResponseMessage> DeleteAgreementAsync(string id)
        {
            var agreement = new HttpClient();
            return await agreement.DeleteAsync($"{baseUrl}api/Agreement/RemoveAgreement/{id}");
        }

        public async Task<Clients[]> GetClientsAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Clients/GetClients");
            return JsonConvert.DeserializeObject<Clients[]>(json);
        }

        public async Task<IEnumerable<JObject>> GetDogovor()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Agreement/GetDogovor");
            Console.WriteLine(json);
            return JsonConvert.DeserializeObject<IEnumerable<JObject>>(json);
        }

        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
