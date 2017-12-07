using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using RaceDay.Contracts.Dto;
using Newtonsoft.Json;

namespace RaceDay.Client
{
    public class WebApiClient
    {
        private System.Net.Http.HttpClient _httpClient;

        public string ServiceUrl { get; set; }

        public WebApiClient()
        {
            ServiceUrl = ConfigurationManager.AppSettings["api:baseUrl"];
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string relativePath)
        {
            var response = new ApiResponse<T>();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, ServiceUrl + relativePath);
            HttpResponseMessage apiResponse = await this.Client.SendAsync(request);

            if (apiResponse.IsSuccessStatusCode)
            {
                var responseData = apiResponse.Content.ReadAsStringAsync().Result;
                
                if (!string.IsNullOrWhiteSpace(responseData))
                {
                    response.IsSuccessful = true;
                    response.Data = JsonConvert.DeserializeObject<T>(responseData);
                }
            }
            else
            {
                response.IsSuccessful = false;
                // TODO: Log Errors
            }

            return response;
        }


        public HttpClient Client
        {
            get
            {
                if (this._httpClient == null)
                {
                    this._httpClient = new HttpClient();
                }

                return this._httpClient;
            }
        }

        
    }
}
