using MVVMSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVVMSample.Services
{
    internal class ToyWebServiceProxy : IToys
    {
        HttpClient client;//יטפל בבקשות ובתשובות מהשרת
        JsonSerializerOptions options;//להגדיר את האופן שבו יתבצעו פעולות הסיריליאזציה והדה סירי
        const string URL = "https://mhmdqzkj-7046.euw.devtunnels.ms/api/ToysApi/";

        public ToyWebServiceProxy()
        {
            //Work With Cookies
            HttpClientHandler handle = new HttpClientHandler() { CookieContainer = new System.Net.CookieContainer() };
            //Create Client
            client = new HttpClient(handle, true);
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, WriteIndented=true };

        }
        public Task<bool> AddToy(Toy toy)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteToy(Toy toy)
        {
            throw new NotImplementedException();
        }

        public Task<List<Toy>> GetToyByType(ToyTypes type)
        {
            throw new NotImplementedException();
        }

        public Task<List<Toy>?> GetToys()
        {
            throw new NotImplementedException();
        }

        public Task<List<Toy>?> GetToysByPriceCondition(double price, bool abovePrice)
        {
            throw new NotImplementedException();
        }

        public Task<List<Toy>?> GetToysByPriceCondition(Predicate<double> condition)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToyTypes>?> GetToyTypes()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Login(string username, string password)
        {
            //create Json
            string json = JsonSerializer.Serialize(new
            {
                Email = username,
                Password = password
            },options);

            //make json available for the httpclient
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync($"{URL}login", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    json=await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<User>(json);
                }
            }
            catch(Exception ex) {  }
            return null;




        }
    }
}
