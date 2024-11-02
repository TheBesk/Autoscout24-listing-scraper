using Autoscout24_listing_scraper;
using Autoscout24_listing_scraper.API;
using Autoscout24_listing_scraper.Model;
using Microsoft.Extensions.Configuration;

// See https://aka.ms/new-console-template for more information
//aggiungere caricamento impostazioni da json, e lancio programma con parametri, + ciclo (timer 10 minuti)
string discord_webhook = "";
string telegram_chat_id = "";
string telegram_bot_token = "";
ApiMethods api = new();
while (true)
{
    List<Annuncio>? old = api.LoadListings();
    List<Annuncio>? elenco = api.ScrapeListings();
    List<Annuncio>? daRimuovere = new();
    foreach (var item in elenco)
    {
        if (old.Any(o => o.linkInserzione == item.linkInserzione))
        {
            daRimuovere.Add(item);
        }
    }
    elenco.RemoveAll(item => daRimuovere.Contains(item));
    api.SendDiscordListing(elenco,discord_webhook);
    api.SendTelegramListing(elenco,telegram_chat_id,telegram_bot_token);
    api.ExportListings(elenco);
    Thread.Sleep(900000);
}