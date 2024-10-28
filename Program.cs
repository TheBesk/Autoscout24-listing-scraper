using Autoscout24_listing_scraper.API;
using Autoscout24_listing_scraper.Model;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
ApiMethods api = new();
List<Listing> test = api.GetListings();
