using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WpfApp2.Model
{
    public class GutendexSession
    {
        public JObject query(string url)
        {           
                using var client = new HttpClient();
            try
            {
                var result = client.GetStringAsync(url);
                var content = result.Result;
                JObject json = JObject.Parse(content);

                return json;                    
            }
            catch (System.Exception)
            {
                JObject json = null;
                return json;          
            }
        }
    }
}
