# movie-rating-platform
Minimalist movie and TV show rating platform built with ASP.NET Core and Angular.

# Upute za pokretanje
- **Otvoriti repozitorij movie-rating-platform**
- **Pronaći arhivu pod nazivom Env_file30072025**
- **Extract .env file iz arhive u isti trenutni folder**
- **.env file bi se trebao nalaziti u folderu movie-rating-platform\movie-rating-platform**
- **Unutar movie-rating-platform\movie-rating-platform, otvoriti terminal i pokrenuti komandu `docker compose up --build` te sačekati da se svi servisi uspješno buildaju**

## Pokretanje aplikacije
- **Nakon builda, aplikaciji pristupiti na: http://localhost:4200**

## Bugfixes & Updates
##  Search Fixes
- **Ispravljeno: Pretraga sada ispravno vraća praznu listu ako nijedan film/TV show ne odgovara unesenoj riječi (ranije su se prikazivali svi itemi).**
- **Ispravljeno: `4 stars` i `at least 4 stars` u smart searchu sada vraćaju različite rezultate, kako je i očekivano.**

## Basic Authentication UI
- **Dodan ekran za login s `Login` dugmetom.**
- **Hardkodiran demo korisnik:**  
  **Username:** `demo`  
  **Password:** `password123`
- **Nakon uspješne autentifikacije, korisnik ima pristup autoriziranom API endpointu `/actor` koji prikazuje listu glumaca.**
- **Ako korisnik nije autentifikovan, API vraća `401 Unauthorized`.**
- **GET Api-s za Movies/TvShows, kao i POST za rating su whitelisted, mogu se koristiti bez autorizacije.**

# Korištene tehnologije
- **ASP.NET Core 8 – za izradu REST API-ja**
- **Entity Framework Core – za pristup bazi podataka**
- **SQL Server – kao sistem za upravljanje bazom podataka**
- **Angular – za razvoj web aplikacije**

# Deployment i Hosting
- **Docker**
- **.env konfiguracija – za parametre baze, porta i sigurnosnih podataka**
- **SQL Server – kao sistem za upravljanje bazom podataka**
- **NGINX – koristi se kao web server za hosting Angular aplikacije u produkcijskom okruženju**


