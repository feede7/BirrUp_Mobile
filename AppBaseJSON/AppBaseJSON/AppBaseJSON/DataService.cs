using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace AppBaseJSON
{
    public class DataService
    {
        public static async Task<dynamic> getDataFromService(string pQueryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(pQueryString);

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                json = json.Replace("[", "");
                json = json.Replace("]", "");
                data = JsonConvert.DeserializeObject("{user:" + json + "}");
            }

            return data;
        }

    }
}
