# Autoscout24 Listing Scraper
## Descrizione
Semplice applicazione  .NET 8 che permette di estrarre gli annunci di auto presenti sul sito web di Autoscout24 e inviarli tramite webhook discord o messaggio telegram con bot api.

## Utilizzo
 Per utilizzare il programma basta modificare il file di configurazione `appconfig.json`:

 -  `discord_webhook`: Incollate il link di un webhook discord che punta ad un server di cui siete amministratori
 - `telegram_bot_token`: create un nuovo bot utilizzando [BotFather](https://telegram.me/BotFather) e incollate il token
 - `telegram_chat_id`: su una chat dove siete amministratori (io ho testato solo su un canale privato, dovrebbe funzionare anche su un gruppo) aggiungete il bot creato in precedenza, dategli i permessi di inviare messaggi, e ottenete l'id della chat dove avete aggiunto il bot (io ho usato [questa](getupdates) api per farlo)
 - `search_query`: dal sito di autoscout effettuate una ricerca e segnatevi l'url dal browser (la query nel file di default funziona)
 - `refresh_minutes`: impostate il tempo che deve trascorrere tra una chiamata e l'altra

È possibile scegliere di inviare soltanto tramite telegram o soltanto tramite discord impostando a `""` i parametri non utilizzati.
