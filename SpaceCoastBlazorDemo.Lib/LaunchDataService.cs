using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCoastBlazorDemo.Lib
{
    public class LaunchDataService
    {

        public async Task<LaunchData[]> GetLaunchesAsync()
        {
            LaunchData[] launches = null;
            using (HttpClient http = new HttpClient())
            {
                try
                {
                    string json = await http.GetStringAsync("https://kentuckerapps.azurewebsites.net/api/spacelaunch");
                    launches = System.Text.Json.JsonSerializer.Deserialize<LaunchData[]>(json);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return launches;
        }
    }
}
