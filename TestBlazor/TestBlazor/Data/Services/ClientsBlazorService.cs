using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace TestBlazor.Data
{
    public class ClientsBlazorService
    {
        string baseUrl = "https://localhost:44393/";

        public async Task<Clients[]> GetClientsAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Clients/GetClients");
            return JsonConvert.DeserializeObject<Clients[]>(json);
        }

       public async Task<Clients> GetClientByIdAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Clients/GetClient/{id}");
            return JsonConvert.DeserializeObject<Clients>(json);
        }

        public async Task<HttpResponseMessage> InsertClientAsync(Clients client)
        {
            var load = new HttpClient();
            return await load.PostAsync($"{baseUrl}api/Clients/AddClients", getStringContentFromObject(client));
        }

        public async Task<HttpResponseMessage> UpdateClientAsync(string id, Clients client)
        {
            var load = new HttpClient();
            return await load.PutAsync($"{baseUrl}api/Clients/UpdateClients/{id}", getStringContentFromObject(client));
        }

        public async Task<HttpResponseMessage> DeleteClientAsync(string id)
        {
            var client = new HttpClient();
            return await client.DeleteAsync($"{baseUrl}api/Clients/RemoveClients/{id}");
        }

        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
