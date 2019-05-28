using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XF3054.Helpers;
using XF3054.Models;

namespace XF3054.Services
{
    public class InvoiceService
    {
        public async Task<InvoiceResponseDTO> CreateInvoiceAsync(LoginResponseDTO loginResponseDTO, InvoiceRequestDTO invoiceRequestDTO)
        {
            InvoiceResponseDTO invoiceResponseDTO = new InvoiceResponseDTO();
            string url = Constants.InvoiceAPI;

            var httpJsonPayload = JsonConvert.SerializeObject(invoiceRequestDTO);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponseDTO.Token);
            HttpResponseMessage response = await client.PostAsync(url,
                new StringContent(httpJsonPayload, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                String strResult = await response.Content.ReadAsStringAsync();
                APIResult apiResult = JsonConvert.DeserializeObject<APIResult>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                if (apiResult.Status == true)
                {
                    string itemJsonContent = apiResult.Payload.ToString();
                    invoiceResponseDTO = JsonConvert.DeserializeObject<InvoiceResponseDTO>(itemJsonContent, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                }
            }
            return invoiceResponseDTO;
        }

        public async Task<List<InvoiceResponseDTO>> RetriveInvoiceAsync(LoginResponseDTO loginResponseDTO)
        {
            List<InvoiceResponseDTO> invoiceResponseDTOs = new List<InvoiceResponseDTO>();
            string url = Constants.InvoiceAPI;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponseDTO.Token);
            HttpResponseMessage response = await client.GetAsync(url);

            String strResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                APIResult apiResult = JsonConvert.DeserializeObject<APIResult>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                if (apiResult.Status == true)
                {
                    string itemJsonContent = apiResult.Payload.ToString();
                    invoiceResponseDTOs = JsonConvert.DeserializeObject<List<InvoiceResponseDTO>>(itemJsonContent, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                }
            }
            return invoiceResponseDTOs;
        }

        public async Task<InvoiceResponseDTO> UpdateInvoiceAsync(LoginResponseDTO loginResponseDTO, InvoiceRequestDTO invoiceRequestDTO)
        {
            InvoiceResponseDTO invoiceResponseDTO = new InvoiceResponseDTO();
            string url = $"{Constants.InvoiceAPI}/{invoiceRequestDTO.Id}";

            var httpJsonPayload = JsonConvert.SerializeObject(invoiceRequestDTO);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponseDTO.Token);
            HttpResponseMessage response = await client.PutAsync(url,
                new StringContent(httpJsonPayload, System.Text.Encoding.UTF8, "application/json"));

            String strResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                APIResult apiResult = JsonConvert.DeserializeObject<APIResult>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                if (apiResult.Status == true)
                {
                    string itemJsonContent = apiResult.Payload.ToString();
                    invoiceResponseDTO = JsonConvert.DeserializeObject<InvoiceResponseDTO>(itemJsonContent, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                }
            }
            return invoiceResponseDTO;
        }

        public async Task<InvoiceResponseDTO> DeleteInvoiceAsync(LoginResponseDTO loginResponseDTO, int Id)
        {
            InvoiceResponseDTO invoiceResponseDTO = new InvoiceResponseDTO();
            string url = $"{Constants.InvoiceAPI}/{Id}";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponseDTO.Token);
            HttpResponseMessage response = await client.DeleteAsync(url);

            String strResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                APIResult apiResult = JsonConvert.DeserializeObject<APIResult>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                if (apiResult.Status == true)
                {
                    string itemJsonContent = apiResult.Payload.ToString();
                    invoiceResponseDTO = JsonConvert.DeserializeObject<InvoiceResponseDTO>(itemJsonContent, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                }
            }
            return invoiceResponseDTO;
        }
    }
}
