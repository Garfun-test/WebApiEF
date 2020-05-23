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
    public class AgreementDetailsBlazorService
    {
        string baseUrl = "https://localhost:44393/";

        public async Task<AgreementDetails[]> GetAgreementDetailsAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/AgreementDetails/GetAgreementDetails");
            return JsonConvert.DeserializeObject<AgreementDetails[]>(json);
        }

        public async Task<AgreementDetails> GetAgreementDetailsByIdAsync(string id, string id2)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/AgreementDetails/GetAgreementDetails/{id}/{id2}");
            return JsonConvert.DeserializeObject<AgreementDetails>(json);
        }

        public async Task<HttpResponseMessage> InsertAgreementDetailsAsync(AgreementDetails agreementDetails)
        {
            var load = new HttpClient();
            return await load.PostAsync($"{baseUrl}api/AgreementDetails/AddAgreementDetails", getStringContentFromObject(agreementDetails));
        }

        public async Task<HttpResponseMessage> UpdateAgreementDetailsAsync(string id, AgreementDetails agreementDetails)
        {
            var load = new HttpClient();
            return await load.PutAsync($"{baseUrl}api/AgreementDetails/UpdateAgreementDetails/{id}", getStringContentFromObject(agreementDetails));
        }

        public async Task<HttpResponseMessage> DeleteAgreementDetailsAsync(string id)
        {
            var agreementDetails = new HttpClient();
            return await agreementDetails.DeleteAsync($"{baseUrl}api/AgreementDetails/RemoveAgreementDetails/{id}");
        }

        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
