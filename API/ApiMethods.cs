using System.Text;
using Autoscout24_listing_scraper.Model;
using System.Text.Json;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Net;

namespace Autoscout24_listing_scraper.API
{
    public class ApiMethods
    {
        public List<Annuncio> LoadListings(string path = "")
        {
            if (string.IsNullOrEmpty(path))
                path = "lista_annunci.json";

            if (!File.Exists(path))
            {
                return new List<Annuncio>();
            }

            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                List<Annuncio> lista = JsonSerializer.Deserialize<List<Annuncio>>(json);
                return lista;
            }
        }
        public void ExportListings(List<Annuncio> newListings, string path = "")
        {
            if (string.IsNullOrEmpty(path))
                path = "lista_annunci.json";

            List<Annuncio> existingListings;
            if (File.Exists(path))
            {
                string existingJson = File.ReadAllText(path);
                existingListings = JsonSerializer.Deserialize<List<Annuncio>>(existingJson) ?? new List<Annuncio>();
            }
            else
                existingListings = new List<Annuncio>();

            existingListings.AddRange(newListings);
            string json = JsonSerializer.Serialize(existingListings);
            File.WriteAllText(path, json);
        }
        public void SendDiscordListing(List<Annuncio> lista, string webhook)
        {
            
            foreach (var item in lista)
            {
                string subtitle = item.nomeDetail != "" ? "## " : "";
                string subsubtitle = item.sottotitolo != "" ? "### " : "";
                string text = "\n";
                text += "#  [" + item.nomeBold + "]" + "(" + item.linkInserzione + ")" + "\n";
                text += $"{subtitle}" + WebUtility.HtmlDecode(item.nomeDetail) + $"\n {subsubtitle}" + WebUtility.HtmlDecode(item.sottotitolo) + "\n";
                text += "## 💶 " + item.prezzo + "\n";
                text += "🌏 " + WebUtility.HtmlDecode(item.localita) + "\n";
                text += "🛣 " + item.km + "\t ⚙️ "+ item.tipoCambio + "\t 📅 "+item.dataVeicolo + "\n";
                text += "⛽ " + item.tipoCarburante + "\t " + "⏲ " + item.potenza;
                text += "\n\n";

                using (var client = new HttpClient())
                {

                    //string iconUrl = "https://www.autoscout24.it/assets/contentservice/images/favicon/favicon-v2-32x32.png";
                    string bigIconUrl = "https://www.autoscout24.it/assets/contentservice/images/favicon/apple-touch-icon.png";
                    client.BaseAddress = new Uri(webhook);
                    var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                    var content = new StringContent(JsonSerializer.Serialize(new { content = text, username = "Autoscout24 nuovi annunci", avatar_url = bigIconUrl }), Encoding.UTF8, "application/json");
                    request.Content = content;
                    if (!string.IsNullOrEmpty(text))
                    {
                        var response = client.SendAsync(request).Result;

                        if (!response.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"Errore: {response.StatusCode}");
                        }
                    }
                    request.Dispose();
                    content.Dispose();
                }
            }
        }

        public void SendTelegramListing(List<Annuncio> lista, string chat_id, string bot_token)
        {
            
            foreach (var item in lista)
            {
                string text = "";
                var link = "[*" + item.nomeBold + "*]" + "(" + item.linkInserzione + ")" + "\n";
                link = Regex.Replace(link, @"\.", @"\.");
                link = Regex.Replace(link, @"\-", @"\-");
                var text2 = "";
                text2 += WebUtility.HtmlDecode(item.nomeDetail) +"\n" + WebUtility.HtmlDecode(item.sottotitolo) + "\n";
                text2 += " 💶 " + item.prezzo + "\n";
                text2 += "🌏 " + WebUtility.HtmlDecode(item.localita) + "\n";
                text2 += "🛣 " + item.km + "\t ⚙️ " + item.tipoCambio + "\t 📅 " + item.dataVeicolo + "\n";
                text2 += "⛽ " + item.tipoCarburante + "\t " + "⏲ " + item.potenza;
                text2 += "\n\n";
                text2 = Regex.Replace(text2, @"\.", @"\.");
                text2 = Regex.Replace(text2, @"\-", @"\-");
                text2 = Regex.Replace(text2, @"\(", @"\(");
                text2 = Regex.Replace(text2, @"\)", @"\)");
                text2 = Regex.Replace(text2, @"\+", @"\+");
                text += link+text2;


            using (var client = new HttpClient())
                {

                    string iconUrl = "https://www.autoscout24.it/assets/contentservice/images/favicon/favicon-v2-32x32.png";
                    string bigIconUrl = "https://www.autoscout24.it/assets/contentservice/images/favicon/apple-touch-icon.png";
                    client.BaseAddress = new Uri($"https://api.telegram.org/bot{bot_token}/sendMessage");
                    var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var values = new System.Collections.Generic.Dictionary<string, string>
                {
                    { "chat_id", $"{chat_id}" },
                    { "text", text },
                    { "parse_mode", "MarkdownV2" }
                };
                var content = new FormUrlEncodedContent(values);
                request.Content = content;
                if (!string.IsNullOrEmpty(text))
                {
                    var response = client.SendAsync(request).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Errore: {response.StatusCode}");
                    }
                }
                request.Dispose();
                content.Dispose();
                }
            }
        }
        /// <summary>
        /// Lettura delle inserzioni corrispondenti ai parametri di ricerca
        /// </summary>
        /// <returns></returns>
        public List<Annuncio> ScrapeListings(string search_query="")
        {
            var url = search_query;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            List<Annuncio> elencoAnnunci = new();

            HtmlNode offerteNode = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div/div/div/div[5]/header/div/div[1]/h1");
            int numeroOfferte = int.Parse(offerteNode.InnerText.Split(' ')[0].Replace(".", ""));
            int limite = 9;
            if (numeroOfferte < 9)
                limite = numeroOfferte;
            for (int i = 1; i <= limite; ++i)
            {
                try
                {
                    string nomeBold = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[2]/a/h2").InnerText;
                    string nomeParte2 = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[2]/a/h2/span").InnerText;
                    string nome = nomeBold;
                    if (nomeParte2 != "")
                        nome = nomeBold.Replace(nomeParte2, "").Trim();
                    string sottotitolo;
                    try
                    {
                       sottotitolo = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[2]/a/span").InnerText;
                    }
                    catch
                    {
                        sottotitolo = "";
                    }
                    string prezzo;
                    try
                    {
                        prezzo = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[3]/div[1]/p").InnerText;
                    }
                    catch (NullReferenceException)
                    {
                        prezzo = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[3]/div[1]/div[2]/span").InnerText;
                    }
                    string km = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[3]/div[3]/span[1]").InnerText;
                    string tipoCambio = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[3]/div[3]/span[2]").InnerText;
                    string data = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[3]/div[3]/span[3]").InnerText;
                    string carburante = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[3]/div[3]/span[4]").InnerText;
                    string potenza = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[3]/div[3]/span[5]").InnerText;
                    string immagine1 = "";
                    string provenienza;
                    try
                    {
                        provenienza = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[2]/span[2]").InnerText;
                    }
                    catch
                    {
                        provenienza = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/span").InnerText;
                    }
                    if (provenienza.Contains("•"))
                        provenienza = provenienza.Split("•")[1];
                    var imgNode = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[1]/section/div[1]/picture/img");
                    if (imgNode != null)
                    {
                        immagine1 = imgNode.GetAttributeValue("src", string.Empty);
                    }
                    //string immagine1 = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[1]/section/div[1]/picture/img").GetAttributeValue("src", string.Empty);
                    string link = doc.DocumentNode.SelectSingleNode($"/html/body/div[1]/div[2]/div/div/div/div[5]/div[3]/main/article[{i}]/div[1]/div[2]/a").GetAttributeValue("href", string.Empty);//.OuterHtml;
                    link = "https://www.autoscout24.it" + link;

                    int indiceVirgola = prezzo.IndexOf(',');
                    if (indiceVirgola != -1)
                    {
                        prezzo = prezzo.Substring(0, indiceVirgola);
                    }
                    Annuncio tmp = new Annuncio()
                    {
                        nomeBold = nome,
                        nomeDetail = nomeParte2,
                        sottotitolo = sottotitolo,
                        prezzo = prezzo,
                        km = km,
                        tipoCambio = tipoCambio,
                        dataVeicolo = data,
                        tipoCarburante = carburante,
                        potenza = potenza,
                        linkInserzione = link,
                        urlPrimaImmagine = immagine1,
                        localita = provenienza
                    };
                    elencoAnnunci.Add(tmp);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"Errore nell'articolo {i}: {ex.Message}");
                    continue;
                }
            }
            return elencoAnnunci;
        }
    }
}
