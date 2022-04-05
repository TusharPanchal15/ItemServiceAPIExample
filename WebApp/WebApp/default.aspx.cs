using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Models;

namespace WebApp
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
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
                string itemname = txtItemName.Text;
                Console.WriteLine(Environment.NewLine);


                var emailObj = new ItemRequest
                {
                    ItemName = itemname,
                    TemplateID = txtTemplateId.Text,
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

                lblError.Text += $"Item Status:\n\r{((HttpWebResponse)response).StatusDescription}";
            }
            catch (Exception ex)
            {
                lblError.Text += $"Error occurred. Message: {ex.Message}.\r\n StackTrace: {ex.StackTrace}.\r\n InnerException: {ex.InnerException}";
            }

        }
    }
}