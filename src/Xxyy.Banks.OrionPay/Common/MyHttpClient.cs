using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xxyy.Banks.Orionpay.Resp;

namespace Xxyy.Banks.Orionpay.Common
{
    public interface IHttp_Client
    {
        Task<string> deleteJson(string url, Dictionary<string, object> header = null);
        Task<TBase<K>> postJson<T, K>(string url, T obj, Dictionary<string, object> header = null);
        Task<string> postJson<T>(string url, T obj, Dictionary<string, object> header = null);
        Task<(string, bool)> postJson(string url, string json, Dictionary<string, object> header = null);
        Task<(string, bool)> postForm(string url, Dictionary<string, string> body, Dictionary<string, object> header = null);
        Task<string> get(string url, string token = "");
        Task<string> upload(string url, string filePath, string fromName);
    }
    public class Http_Client : IHttp_Client
    {
        public HttpClient httpClient;
        public Http_Client() //IHttpClientFactory clientFactory
        {
            var httpHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true,
                UseCookies = false
            };
            this.httpClient = new HttpClient(httpHandler); //clientFactory.CreateClient("HttpClientHost");
            this.httpClient.Timeout = TimeSpan.FromSeconds(60);

        }

        public async Task<TBase<K>> postJson<T, K>(string url, T obj, Dictionary<string, object> header = null)
        {
            TBase<K> responce = new TBase<K>() { success = false };
            try
            {
                HttpContent content = null;
                if (obj != null)
                {
                    string json = JsonConvert.SerializeObject(obj);
                    content = new StringContent(json, Encoding.UTF8, "application/json");
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/json");
                }
                if (header != null && header.Any())//!string.IsNullOrEmpty(token)
                {
                    foreach (var kvp in header)
                    {
                        string key = kvp.Key.ToLower();
                        string value = kvp.Value?.ToString();
                        if ("bearer" == key)
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", value);
                        }
                        else if ("basic" == key) //{user}:{password}
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Convert.ToBase64String(Encoding.UTF8.GetBytes(value)));
                        }
                        else
                        {
                            httpClient.DefaultRequestHeaders.Remove(key);
                            httpClient.DefaultRequestHeaders.Add(key, value);
                        }
                    }
                }
                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), content);
                response.EnsureSuccessStatusCode();
                responce.success = true;
                responce.data = await response.Content.ReadFromJsonAsync<K>();
            }
            catch (NullReferenceException ex1)
            {
                //JObject.FromObject(responceMessage)
                responce.message = ex1.Message;
            }
            catch (HttpRequestException ex2)
            {
                //MessageResponse responceMessage = new MessageResponse(false, 0, "No se puede conectar con el servidor.");
                responce.message = ex2.Message;
            }
            catch (Exception ex3)
            {
                responce.message = ex3.Message;
            }
            return responce;
        }

        public async Task<string> postJson<T>(string url, T obj, Dictionary<string, object> header = null)
        {
            string responce = "";
            try
            {
                HttpContent content = null;
                if (obj != null)
                {
                    string json = JsonConvert.SerializeObject(obj);
                    content = new StringContent(json, Encoding.UTF8, "application/json");
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/json");
                }
                if (header != null && header.Any())
                {
                    foreach (var kvp in header)
                    {
                        string key = kvp.Key.ToLower();
                        string value = kvp.Value?.ToString();
                        if ("bearer" == key)
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(key, value);
                        }
                        else if ("basic" == key)//{user}:{password}
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(key, Convert.ToBase64String(Encoding.UTF8.GetBytes(value)));
                        }
                        else
                        {
                            httpClient.DefaultRequestHeaders.Remove(key);
                            httpClient.DefaultRequestHeaders.Add(key, value);
                        }
                    }
                }
                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), content);
                response.EnsureSuccessStatusCode();
                responce = await response.Content.ReadAsStringAsync();

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

        public async Task<(string,bool)> postJson(string url, string json, Dictionary<string, object> header = null)
        {
            string responce = "";
            bool flag = false;
            try
            {
                HttpContent content = null;
                if (!string.IsNullOrWhiteSpace(json))
                {
                    content = new StringContent(json, Encoding.UTF8, "application/json");
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/json");
                }

                if (header != null && header.Any())
                {
                    foreach (var kvp in header)
                    {
                        string key = kvp.Key.ToLower();
                        string value = kvp.Value?.ToString();
                        if ("bearer" == key)
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(key, value);
                        }
                        else if ("basic" == key)//{user}:{password}
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(key, Convert.ToBase64String(Encoding.UTF8.GetBytes(value)));
                        }
                        else
                        {
                            httpClient.DefaultRequestHeaders.Remove(key);
                            httpClient.DefaultRequestHeaders.Add(key, value);
                        }
                    }
                }
                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), content);
                response.EnsureSuccessStatusCode();
                responce = await response.Content.ReadAsStringAsync();
                flag = true;
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
            return (responce,flag);
        }

        public async Task<string> deleteJson(string url, Dictionary<string, object> header = null)
        {
            string responce = "";
            try
            {
                //HttpContent content = null;
                //if (!string.IsNullOrWhiteSpace(json))
                //{
                //    content = new StringContent(json, Encoding.UTF8, "application/json");
                //    content.Headers.Clear();
                //    content.Headers.Add("Content-Type", "application/json");
                //}

                if (header != null && header.Any())//!string.IsNullOrEmpty(token)
                {
                    foreach (var kvp in header)
                    {
                        string key = kvp.Key.ToLower();
                        string value = kvp.Value?.ToString();
                        if ("bearer" == key)
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", value);
                        }
                        else if ("basic" == key)//{user}:{password}
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Convert.ToBase64String(Encoding.UTF8.GetBytes(value)));
                        }
                        else
                        {
                            httpClient.DefaultRequestHeaders.Remove(key);
                            httpClient.DefaultRequestHeaders.Add(key, value);
                        }

                    }
                }
                HttpResponseMessage response = await httpClient.DeleteAsync(new Uri(url));
                response.EnsureSuccessStatusCode();
                responce = await response.Content.ReadAsStringAsync();
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

        public async Task<(string,bool)> postForm(string url, Dictionary<string, string> body, Dictionary<string, object> header = null)
        {
            string responce = "";
            bool result = false;
            try
            {
                HttpContent content = null;
                if (body != null && body.Any())
                {
                    content = new FormUrlEncodedContent(body);
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                }
                if (header != null && header.Any())
                {
                    foreach (var kvp in header)
                    {
                        string key = kvp.Key.ToLower();
                        string value = kvp.Value?.ToString();
                        if ("bearer" == key)
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(key, value);
                        }
                        else if ("basic" == key)//{user}:{password}
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(key, Convert.ToBase64String(Encoding.UTF8.GetBytes(value)));
                        }
                        else
                        {
                            httpClient.DefaultRequestHeaders.Remove(key);
                            httpClient.DefaultRequestHeaders.Add(key, value);
                        }
                    }
                }

                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), content);
                response.EnsureSuccessStatusCode();
                responce = await response.Content.ReadAsStringAsync();
                result = true;
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
            return (responce,result);
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
                response.EnsureSuccessStatusCode();
                responce = await response.Content.ReadAsStringAsync();
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

        public async Task<string> upload(string url, string filePath, string fromName)
        {
            using (var client = new HttpClient())
            {
                //FileStream imagestream = System.IO.File.OpenRead(filePath);
                // multipartFormDataContent.Add();
                var multipartFormDataContent = new MultipartFormDataContent()
                {
                    {
                        new ByteArrayContent(System.IO.File.ReadAllBytes(filePath)),    // 文件流
                        fromName,                                                       // 对应 服务器 WebAPI 的传入参数
                        Path.GetFileName(filePath)                                      // 上传的文件名称
                    }
                };
                /* 
                 * 如果服务器 API 写法是
                 * ([FromForm]IFromFile files)
                 * 那么上面的 fromName="files"
                 */
                //multipartFormDataContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                //如果是List<IFormFile> files则不需要

                HttpResponseMessage response = await client.PostAsync(url, multipartFormDataContent);
                if (!response.IsSuccessStatusCode)
                {

                    Console.WriteLine("up image error");
                    Console.WriteLine(response.RequestMessage);
                }
                return "true";
            }
        }
    }

}
