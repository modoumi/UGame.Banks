using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Tejeepay.Common
{
    public interface IHttp_Client
    {
        Task<string> postJson(string url, string json, Dictionary<string, object> header = null);
        Task<string> postForm(string url, Dictionary<string, string> body, Dictionary<string, object> header = null);
        Task<string> get(string url, string token = "");
    }
    public class Http_Client : IHttp_Client
    {
        public HttpClient httpClient;
        public Http_Client()//IHttpClientFactory clientFactory
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = delegate { return true; }
            };
            this.httpClient = new HttpClient(httpClientHandler);//clientFactory.CreateClient("HttpClientHost");
            this.httpClient.Timeout = TimeSpan.FromSeconds(60);
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

        
            
        }
        public async Task<string> postJson(string url, string json , Dictionary<string, object> header=null) //string token = ""
        {
            string responce = "";
            try
            {
                HttpContent content = null;
                if (!string.IsNullOrWhiteSpace(json))
                {
                    content = new StringContent(json, Encoding.UTF8, "application/json");
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/json");
                }
                //foreach(var kvp in header)
                //{
                //    content.Headers.Add(kvp.Key, kvp.Value?.ToString());
                //}
                if (header!=null && header.Any())//!string.IsNullOrEmpty(token)
                {
                    foreach(var kvp in header)
                    {
                        string key = kvp.Key;
                        string value = kvp.Value?.ToString();
                        if (key== "bearer")
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", value);
                        }
                        httpClient.DefaultRequestHeaders.Remove(key);
                        httpClient.DefaultRequestHeaders.Add(key, value);
                    }
                   
                }
                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), content);
                var responceString = await response.Content.ReadAsStringAsync();
                responce = responceString;

            }
            catch (NullReferenceException ex1)
            {
                //JObject.FromObject(responceMessage)
                responce = ex1.Message;
            }
            catch (HttpRequestException ex2)
            {
                //MessageResponse responceMessage = new MessageResponse(false, 0, "No se puede conectar con el servidor.");
                responce = ex2.Message;
            }
            catch (Exception ex3)
            {
                responce = ex3.Message;
            }
            return responce;
        }

        public async Task<string> postForm(string url, Dictionary<string, string> body, Dictionary<string, object> header = null)//string token = ""
        {
            string responce = "";
            try
            {
                HttpContent content = null;
                if (body != null && body.Any())
                {
                    content = new FormUrlEncodedContent(body);
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                }
                if (header != null&& header.Any())
                {
                    foreach (var kvp in header)
                    {
                        string key = kvp.Key;
                        string value = kvp.Value?.ToString();
                        if (key == "bearer")
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", value);
                        }
                        httpClient.DefaultRequestHeaders.Remove(key);
                        httpClient.DefaultRequestHeaders.Add(key, value);
                    }
                }
                   
                //if (!string.IsNullOrEmpty(token))
                //{
                //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                //}
                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), content);
                var responceString = await response.Content.ReadAsStringAsync();
                responce = responceString;
            }
            catch (NullReferenceException ex1)
            {
                //JObject.FromObject(responceMessage)
                responce = ex1.Message;
            }
            catch (HttpRequestException ex2)
            {
                //MessageResponse responceMessage = new MessageResponse(false, 0, "No se puede conectar con el servidor.");
                responce = ex2.Message;
            }
            catch (Exception ex3)
            {
                responce = ex3.Message;
            }
            return responce;
        }

        public async Task<string> get(string url, string token = "")
        {
            string responce;
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                }
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(url));
                var responceString = await response.Content.ReadAsStringAsync();
                responce = responceString;
            }
            catch (NullReferenceException ex1)
            {
                //JObject.FromObject(responceMessage)
                responce = ex1.Message;
            }
            catch (HttpRequestException ex2)
            {
                //MessageResponse responceMessage = new MessageResponse(false, 0, "No se puede conectar con el servidor.");
                responce = ex2.Message;
            }
            catch (Exception ex3)
            {
                responce = ex3.Message;
            }
            return responce;
        }
    }
   
}
