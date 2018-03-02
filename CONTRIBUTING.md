# Conventies
# Trello

 - User Stories: hierin beschrijf je de actie die door een gebruiker, systeem, etc. uitgevoerd kan worden. 
 - Tickets: specefiekere taken die onder een User Story vallen
 - Bij een nieuwe sprint kopieer je de relevante User Stories en Tickets naar het nieuwe sprint board. 
 - Tickets linken aan User Stories is als volgt: klik op ticket>bijlage>Trello>Klik op de User Story>verbind kaart
 - Tickets en User Stories worden doorlopend genummerd: #(nummer) (User Story of Ticker naam)
 - Defenition of Done (DoD) wordt staat in de beschrijving van het ticket.

# GitHub

 - Schrijf alles in het Engels
 - Gebruik alleen kleine letters in branch names

## Branches

Master

 - Nooit op master committen -> gevaarlijk 
 - De Repo owner commit hier werkende releas versies op

Develop

 - Hier merge je je eigen feature branch naartoe als je tickets af zijn en het een werkende versie is
 - Doe dit regelmatig, merge daarna develop ook weer terug in je eigen feature branche zodat je de laatste versie hebt
 - Wees niet koppig, just do it

"Feature Branches"

 - Hierop commit je alleen je eigen zaken
 - Dit voorkomt dat je elkaars werk gaat overschrijven
 - Voorbeeld naam: "feature/#3-user-login"
 - De naam is op basis van de betreffente User Story
 - Door "feature/" voor de naam te typen wordt er een mapje in git aangemaakt met daarin alle feature branches
 - Het nummer staat voor het User Story nummer 
 - Houd het kort en bondig
 - Overleg met elkaar hoe zo'n branche moet gaan heten
 - Het is namelijk lastig om lange zin om te zetten naar een paar steekwoorden


## Commits

 - Commit alleen iets als het ook echt werkt
 - Tenzei je echt niet anders kan, maar commit dan ook echt alleen naar je eigen branch
 - Schijf duidelijke commit messages
 - Begin je commit message met het nummer van het ticket waaraan je hebt gewerkt
 - Zo dus: "#5 Added a file to make it work"
 - "Fixed some shit" - FOUT!
 - Beschijf wat het doet of toevoegd
