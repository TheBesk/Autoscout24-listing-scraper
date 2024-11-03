using Autoscout24_listing_scraper.API;
using Autoscout24_listing_scraper.Model;
using Microsoft.Extensions.Configuration;

// See https://aka.ms/new-console-template for more information
//aggiungere caricamento impostazioni da json, e lancio programma con parametri, + ciclo (timer 10 minuti)
var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appconfig.json", optional: false, reloadOnChange: true)
                .Build();
string discord_webhook = configuration["AppSettings:discord_webhook"];
string telegram_chat_id = configuration["AppSettings:telegram_chat_id"];
string telegram_bot_token = configuration["AppSettings:telegram_bot_token"];
string search_query = configuration["AppSettings:search_query"];
int refresh_minutes = int.Parse(configuration["AppSettings:refresh_minutes"]);
ApiMethods api = new();
while (true)
{
    List<Annuncio>? old = api.LoadListings();
    List<Annuncio>? elenco = api.ScrapeListings(search_query);
    List<Annuncio>? daRimuovere = new();
    foreach (var item in elenco)
    {
        if (old.Any(o => o.linkInserzione == item.linkInserzione))
        {
            daRimuovere.Add(item);
        }
    }
    elenco.RemoveAll(item => daRimuovere.Contains(item));
    if (!string.IsNullOrEmpty(discord_webhook))
        api.SendDiscordListing(elenco,discord_webhook);
    if (!string.IsNullOrEmpty(telegram_chat_id) && !string.IsNullOrEmpty(telegram_bot_token))
        api.SendTelegramListing(elenco,telegram_chat_id,telegram_bot_token);
    api.ExportListings(elenco);
    Console.WriteLine("invio completato in data " + DateTime.Now);
    Thread.Sleep(refresh_minutes*60000);
}