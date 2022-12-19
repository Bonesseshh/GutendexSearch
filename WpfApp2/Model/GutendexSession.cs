using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2.Model
{
    public class GutendexSession
    {

        public JObject query(string url)
        {
            
            
                using var client = new HttpClient();

                var result = client.GetStringAsync(url);
                var content = result.Result;
                JObject json = JObject.Parse(content);

                return json;
            
           
            
        }
    }
}
