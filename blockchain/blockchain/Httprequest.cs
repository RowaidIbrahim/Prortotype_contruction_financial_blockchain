using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.IO;

namespace blockchain
{
    public class Httprequest
    {
        public string post(string URL, Object item)
        {
            string result;
            var client = new HttpClient();
            string json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(URL, content).Result;
            if (response.IsSuccessStatusCode)
                {
                    //result = response.StatusCode.ToString();
                    var s = response.Content.ReadAsStringAsync();
                    string r = s.Result.ToString();
                    result = r;
                }
             else
                {
                    var s = response.Content.ReadAsStringAsync();
                    string r = s.Result.ToString();
                    result = r;
                }
            
           
            return result;
        }
        public dynamic get(string URL)
        {
            JsonSerializer serializer = new JsonSerializer();
            var client = new HttpClient();
            var content = client.GetStringAsync(URL);
            string response = content.Result.ToString();
            dynamic jsonResponse = JsonConvert.DeserializeObject(response);
            return jsonResponse;

        }
    }
}
