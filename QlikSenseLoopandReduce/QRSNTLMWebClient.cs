using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Security.Principal;
using RestSharp;

namespace QlikSenseLoopandReduce
{
    public class QRSNTLMWebClient
    {
        private readonly RestClient _client;

        RestRequest request;
        public CookieContainer QRSCookieContainer = new CookieContainer();

        public QRSNTLMWebClient(string QRSserverURL)
        {
            _client = new RestClient(QRSserverURL);
            _client.UserAgent = "Windows";
            _client.CookieContainer = QRSCookieContainer;

            Get("/qrs/about");
        }


        public string Get(string url)
        {
            return Get(url, null);
        }

        public string Get(string endpoint, Dictionary<string, string> queries)
        {
            SetupRequest(endpoint, Method.GET);

            if (queries != null)
            {
                foreach (KeyValuePair<string, string> query in queries)
                    request.AddParameter(query.Key, query.Value, ParameterType.QueryString);
            }

            IRestResponse response = _client.Execute(request);
            var responsecontent = response.Content;
            return responsecontent;

        }

        public string Put(string endpoint, string content)
        {

            SetupRequest(endpoint, Method.PUT);

            IRestResponse response = _client.Execute(request);
            var responsecontent = response.Content;
            return responsecontent;

        }

        public string Put(string endpoint, Dictionary<string, string> queries)
        {

            SetupRequest(endpoint, Method.PUT);

            if (queries != null)
            {
                foreach (KeyValuePair<string, string> query in queries)
                    request.AddParameter(query.Key, query.Value, ParameterType.QueryString);
            }

            IRestResponse response = _client.Execute(request);
            var responsecontent = response.Content; 
            return responsecontent;

        }

        public byte[] PutFile(string endpoint, string filepath)
        {
            SetupRequest(endpoint, Method.GET);

            request.AddFile("app", filepath);

            IRestResponse response = _client.Execute(request);
            var responsecontent = response.RawBytes;
            return responsecontent;

        }

        public string Post(string endpoint, string content)
        {
            return Post(endpoint, content, null);
        }

        public string Post(string endpoint, string content, Dictionary<string, string> queries)
        {
            SetupRequest(endpoint, Method.POST);

            if (queries != null)
            {
                foreach (KeyValuePair<string, string> query in queries)
                request.AddParameter(query.Key, query.Value, ParameterType.QueryString);
            }

            request.AddParameter("application/json", content, ParameterType.RequestBody);

            IRestResponse response = _client.Execute(request);
            var responsecontent = response.Content;
            return responsecontent;
        }

        public string PostFile(string endpoint, string filepath, Dictionary<string, string> queries)
        {
            SetupRequest(endpoint, Method.POST);

            if (queries != null)
            {
                foreach (KeyValuePair<string, string> query in queries)
                    request.AddParameter(query.Key, query.Value, ParameterType.QueryString);
            }

            request.AddFile("app", filepath);

            IRestResponse response = _client.Execute(request);
            var responsecontent = response.RawBytes;
            return Encoding.UTF8.GetString(responsecontent, 0, responsecontent.Length);


        }

        public string Delete(string endpoint)
        {
            SetupRequest(endpoint, Method.DELETE);

            IRestResponse response = _client.Execute(request);
            var responsecontent = response.Content;
            return responsecontent;
        }




        private void SetupRequest(string endpoint, Method method)
        {
            request = new RestRequest(endpoint, method);
            request.AddParameter("xrfkey", "ABCDEFG123456789",ParameterType.QueryString); 
            request.AddHeader("Accept-Charset", "utf-8");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-Qlik-xrfkey", "ABCDEFG123456789");
            request.UseDefaultCredentials = true;
            request.RequestFormat = DataFormat.Json;

        }


    }

}

