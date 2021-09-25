using System.Net;       //to fetch the data from server
using Newtonsoft.Json;  //to parse the JSON data which gets returned by the server
using System.Net.Http;  //it provides a programming interface for modern HTTP application
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Image_Gallery_Demo
{
    class DataFetcher
    {
        public async Task<string> GetDatafromService(string searchstring)
        {
            string readText = null;
            try
            {
                string url = @"https://imagefetcherapi.azurewebsites.net/api/fetch_images?query=" +
                                searchstring + "&max_count=5";
                using (HttpClient c = new HttpClient())      
                {
                    readText = await c.GetStringAsync(url);
                }
            }
            catch
            {
                readText =
               File.ReadAllText(@"Data/sampleData.json");
            }
            return readText;
        }
        // to parse the JSON data returned.
        public async Task<List<ImageItem>> GetImageData(string search)
        {
            string data = await GetDatafromService(search);
            // to parse the json data into an instance of ImageItem
            return JsonConvert.DeserializeObject<List<ImageItem>>(data);
        }
    }    
}
