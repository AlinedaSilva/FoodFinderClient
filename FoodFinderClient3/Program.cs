using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            Console.WriteLine("Enter search text: ");
            MakeRequest(Console.ReadLine());
            Console.ReadLine();
        }

        static async void MakeRequest(string query)
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "56ac439a92694577a2779f3d0ee0cd85");

            var uri = string.Format("https://dev.tescolabs.com/grocery/products/?query={0}&offset={1}&limit={2}", query, 0, 10);

            var response = await client.GetAsync(uri);
            Console.WriteLine(response.ToString());
            string body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
        }
    }
}