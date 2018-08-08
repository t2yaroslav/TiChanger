﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using TIC.ApiClient.Model;


namespace TIC.ApiClient
{
    public class Rest
    {
        private static string username = "t2yaroslav@gmail.com";
        private static string password = "Ok2Yaroslav";
        private static string baseUrl = "https://x.okchanger.com";
        private readonly RestClient _client;

        public Rest()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            Console.WriteLine("new RestClient");
            _client = new RestClient(baseUrl);
            _client.AddHandler("text/plain", new JsonDeserializer());
            //client.Authenticator = new HttpBasicAuthenticator(username, password);

            Console.WriteLine("login");
            var requestLogin = new RestRequest("api/Login", Method.POST);
            requestLogin.AddParameter("Account", username);
            requestLogin.AddParameter("Password", password);

            IRestResponse responseLogin = _client.Execute(requestLogin);
            ApplyCookie(responseLogin.Cookies);
        }

        public Exchangers GetExchangerList(ExchangersListFilter filter)
        {
            Console.WriteLine("GetExchangersList");
            //var request = CreateRequest("api/GetExchangersList", Method.GET, "{\"filter\":{\"UserID\":\"\",\"Text\":\"\",\"Url\":\"\",\"OKPAYWallet\":\"\",\"WMID\":\"\",\"Statuses\":[],\"IsFollowURLCorrect\":\"\",\"HasRatesErrors\":\"\",\"IsRefURLEmpty\":\"\",\"IsHidden\":\"\",\"IsUntrusted\":\"\"},\"startFrom\":0}");
            var request = new RestRequest("api/GetExchangersList", Method.POST);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.AddJsonBody(filter);
            
            IRestResponse<Exchangers> restResponse = _client.Execute<Exchangers>(request);
            return restResponse.Data;
        }

        private void ApplyCookie(IList<RestResponseCookie> responseLoginCookies)
        {
            var sessionCookie = responseLoginCookies.FirstOrDefault();
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