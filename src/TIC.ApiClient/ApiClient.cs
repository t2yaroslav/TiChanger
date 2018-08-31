using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using RestSharp;
using RestSharp.Deserializers;
using TIC.ApiClient.Model;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;


namespace TIC.ApiClient
{
    public class ApiClient
    {
        private static string username = "t2yaroslav@gmail.com";
        private static string password = "Ok2Yaroslav";
        private static string baseUrl = "https://x.okchanger.com";
        private readonly RestClient _client;
        private IList<RestResponseCookie> _cookies;
        private string _cookiesFileName = "cookies.json";

        public ApiClient()
        {
            // ignore ssl certificate errors
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            Console.WriteLine("Create RestClient " + baseUrl);
            _client = new RestClient(baseUrl);
            _client.AddHandler("text/plain", new JsonDeserializer());
            
            LoadCookies();
            if (_cookies == null)
            {
                _cookies = Login();
                SaveCookies();
            }

            ApplyCookie();
        }

        private IList<RestResponseCookie> Login()
        {
            Console.WriteLine("api/Login: " + username);
            var requestLogin = new RestRequest("api/Login", Method.POST);
            requestLogin.AddParameter("Account", username);
            requestLogin.AddParameter("Password", password);
            IRestResponse responseLogin = _client.Execute(requestLogin);
            
            return responseLogin.Cookies;
        }

        public Exchangers GetExchangerList(ExchangersListFilter filter)
        {
            var apiGetexchangerslist = "api/GetExchangersList";

            var request = new RestRequest(apiGetexchangerslist, Method.POST);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.AddJsonBody(filter);

            IRestResponse<Exchangers> restResponse = ExecuteRequest<Exchangers>(request);
            
            Console.WriteLine(apiGetexchangerslist + ":" + restResponse?.Data?.Collection?.ItemsCount);
            
            return restResponse.Data;
        }

        private IRestResponse<T> ExecuteRequest<T>(RestRequest request) where T : new()
        {
            var result = _client.Execute<T>(request);
            
            // under construction
            //if (result.ContentLength == -1)
            //{
            //    _cookies = Login();
            //    SaveCookies();
            //}
            
            if (result.ErrorException!=null)
                throw new Exception(result.ErrorMessage, result.ErrorException);
            
            return result;
        }

        private void LoadCookies()
        {
            try
            {
                using (StreamReader file = File.OpenText(_cookiesFileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    _cookies = (IList<RestResponseCookie>) serializer.Deserialize(file,
                        typeof(IList<RestResponseCookie>));
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
            }
        }

        private void SaveCookies()
        {
            using (StreamWriter file = File.CreateText(_cookiesFileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, _cookies);
            }
        }
        private void ApplyCookie()
        {
            var sessionCookie = _cookies.FirstOrDefault();
            if (sessionCookie != null)
            {
                Console.WriteLine("Apply Cookie - " + sessionCookie.Name);
                var cookieContainer = new CookieContainer();
                cookieContainer.Add(new Cookie(sessionCookie.Name, sessionCookie.Value, sessionCookie.Path,
                    sessionCookie.Domain));
                _client.CookieContainer = cookieContainer;
            }
            else throw new Exception("No found cookies");
        }
        
    }
}