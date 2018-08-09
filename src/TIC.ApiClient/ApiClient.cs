using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
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
            Console.WriteLine("api/GetExchangersList");

            var request = new RestRequest("api/GetExchangersList", Method.POST);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.AddJsonBody(filter);

            IRestResponse<Exchangers> restResponse = _client.Execute<Exchangers>(request);
            return restResponse.Data;
        }

        private void ApplyCookie()
        {
            var sessionCookie = _cookies.FirstOrDefault();
            if (sessionCookie != null)
            {
                Console.WriteLine("Cookie - " + sessionCookie.Name);
                var cookieContainer = new CookieContainer();
                cookieContainer.Add(new Cookie(sessionCookie.Name, sessionCookie.Value, sessionCookie.Path,
                    sessionCookie.Domain));
                _client.CookieContainer = cookieContainer;
            }
            else throw new Exception("No found cookies");
        }
    }
}