using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortExample
{
    public class DeployBuild
    {
        private const string URL = "http://localhost:3435/httpAuth/app/rest/buildQueue";

        public void Deploy()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            HttpRequestMessage request = new HttpRequestMessage();
            request.Content = new StringContent("<build><buildType id='JavaProjectDemo_1Commit'/></build>");
            request.Method = HttpMethod.Post;
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", "Z2FnYW4xOmdhZ2Fu");

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

            // ("Content-Type", "application/xml")

            HttpResponseMessage response = client.SendAsync(request).Result;


        }
    }
}
