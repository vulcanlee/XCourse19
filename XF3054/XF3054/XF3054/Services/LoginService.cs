using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XF3054.Helpers;
using XF3054.Models;

namespace XF3054.Services
{
    public class LoginService
    {
        public LoginResponseDTO item;
        // 使用者帳號與密碼可以使用 user1~user50 / password1~password50
        public async Task LoginAsync(string account, string password)
        {
            string url = "https://lobworkshop.azurewebsites.net/api/Login";
            LoginRequestDTO loginRequestDTO = new LoginRequestDTO()
            {
                Account = account,
                Password = password
            };
            var httpJsonPayload = JsonConvert.SerializeObject(loginRequestDTO);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url,
                new StringContent(httpJsonPayload, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                String strResult = await response.Content.ReadAsStringAsync();
                APIResult apiResult = JsonConvert.DeserializeObject<APIResult>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                if (apiResult.Status == true)
                {
                    string itemJsonContent = apiResult.Payload.ToString();
                    item = JsonConvert.DeserializeObject<LoginResponseDTO>(itemJsonContent, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });

                    string content = JsonConvert.SerializeObject(item);
                    await StorageUtility.WriteToDataFileAsync(Constants.DataFolder, Constants.LoginServiceFilename, content);
                }
            }
        }

        public async Task Read()
        {
            string content = await StorageUtility.ReadFromDataFileAsync(Constants.DataFolder, Constants.LoginServiceFilename);
            item = JsonConvert.DeserializeObject<LoginResponseDTO>(content);
            if (item == null) item = new LoginResponseDTO();
        }

    }
}
