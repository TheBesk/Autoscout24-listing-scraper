using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoscout24_listing_scraper.Model;
using System.Text.Json;

namespace Autoscout24_listing_scraper.API
{
    public class ApiMethods
    {
        public List<Listing> GetListings()
        {
            Rootobject? listings = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.autoscout24.it/_next/data/as24-search-funnel_main-445/lst.json");
                client.DefaultRequestHeaders.Add("sort", "standard");
                client.DefaultRequestHeaders.Add("desc", "0");
                client.DefaultRequestHeaders.Add("priceto", "5000");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress);
                var response = client.Send(request);
                listings = JsonSerializer.Deserialize<Rootobject>(response.Content.ReadAsStream());
                
            }
            return listings.pageProps.listings.ToList();
        }
    }
}
