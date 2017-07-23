using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RestaurantsAPI
{
    public class Restaurants
    {
        const string ApiURL = "http://api.gnavi.co.jp/RestSearchAPI/20150630/";

        const string keyid = "4b459c82d6c82a40f653dfd1c031f70c";

        public Restaurants()
        {
        }

		private async Task<string> HttpGetAsync(string url)
		{
			HttpClient httpClient = new HttpClient();

			Task<string> getStringTask = httpClient.GetStringAsync(url);

			string result = await getStringTask;

			return result;
		}

        public JObject getRestaurantsByCoordinates(double lati/* tude */, double longi/* tude */)
        {

            string URL = ApiURL + "?keyid=" + keyid + "&format=json" + "&latitude=" + lati + "&longitude" + longi + "&range=5"; // Range = 1||2||3||4||5 500-3000m
			string json = "";

			Task task = new Task(() =>
			{
				json = HttpGetAsync(URL).Result;
			});
			task.Start();
			task.Wait();

			return JObject.Parse(json);
        }


    }
}
