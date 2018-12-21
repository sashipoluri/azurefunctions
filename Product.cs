using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace Sashi.FirstFunction
{
    public class Product
    {
         public string sku {get; set; }
         public string name {get; set;}

    }

    public class ProductRepository
    {
        HttpClient client = new HttpClient();
        public async Task<Product> GetAsync()
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync("https://m.bestbuy.ca/api/mccp/v2/json/product/12598561");
            if(response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;

        }
    } 
}