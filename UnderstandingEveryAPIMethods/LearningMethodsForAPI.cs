using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace UnderstandingEveryAPIMethods
{
    public class LearningMethodsForAPI
    {
        public string name { get; set; }
        public string surname { get; set; }
        static void Main(string[] args)
        {
            GetApiData("https://spoonacular.com/food-api");
        }

        private static void GetApiData(string apiurl)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(apiurl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Values").Result;


            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(response);
                foreach (var item in products)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void PostApiData(string url) 
        {
            using (var client = new HttpClient())
            {
                LearningMethodsForAPI p = new LearningMethodsForAPI { name = "Hrishikesh", surname = "Yadav" };
                client.BaseAddress = new Uri(url);
                var response = client.PostAsJsonAsync("api/person", p).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }
        }
    }
}
