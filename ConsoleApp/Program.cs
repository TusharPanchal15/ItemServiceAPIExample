using ConsoleApp.Model;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
         

        static void Main(string[] args)
        {
            try
            {

                string domainName = "https://demosc.dev.local";
                string loginAPI = "/sitecore/api/ssc/auth/login";
                string logout = "/sitecore/api/ssc/auth/login";
                string itemAPI = "/sitecore/api/ssc/item/";
                string ItemLocation = "sitecore%2Fcontent%2Fhome";


                var authUrl = $"{domainName}{loginAPI}";
                var authData = new Authentication
                {
                    Domain = "sitecore",
                    Username = "admin",
                    Password = "demo"
                };

                var authRequest = (HttpWebRequest)WebRequest.Create(authUrl);

                authRequest.Method = "POST";
                authRequest.ContentType = "application/json";

                var requestAuthBody = JsonConvert.SerializeObject(authData);

                var authDatas = new UTF8Encoding().GetBytes(requestAuthBody);

                using (var dataStream = authRequest.GetRequestStream())
                {
                    dataStream.Write(authDatas, 0, authDatas.Length);
                }

                CookieContainer cookies = new CookieContainer();

                authRequest.CookieContainer = cookies;

                var authResponse = authRequest.GetResponse();

                Console.WriteLine($"Login Status:\n\r{((HttpWebResponse)authResponse).StatusDescription}");

                authResponse.Close();

                Console.WriteLine("Enter Item Name:");
                string itemname = Console.ReadLine();
                Console.WriteLine(Environment.NewLine);
                

                var emailObj = new ItemRequest
                {
                    ItemName = itemname,
                    TemplateID = "{76036F5E-CBCE-46D1-AF0A-4143F9B557AA}",
                    Title = "Test API TITLE",
                    Text = "TEST API TEXT"
                };

                var url = $"{domainName}{itemAPI}{ItemLocation}?sc_content=master";

                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "POST";
                request.ContentType = "application/json";
                request.CookieContainer = cookies;

                var requestBody = JsonConvert.SerializeObject(emailObj);

                var data = new UTF8Encoding().GetBytes(requestBody);

                using (var dataStream = request.GetRequestStream())
                {
                    dataStream.Write(data, 0, data.Length);
                }

                var response = request.GetResponse();

                Console.WriteLine($"Item Status:\n\r{((HttpWebResponse)response).StatusDescription}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred. Message: {ex.Message}.\r\n StackTrace: {ex.StackTrace}.\r\n InnerException: {ex.InnerException}");
            }
            Console.ReadKey();
        }
    }
}
