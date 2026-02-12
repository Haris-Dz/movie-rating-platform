# movie-rating-platform
Minimalist movie and TV show rating platform built with ASP.NET Core and Angular.

# Setup Instructions
- **Open the movie-rating-platform repository**
- **Locate the archive named Env_file30072025**
- **Extract the .env file from the archive into the same current folder**
- **The .env file should be placed inside the movie-rating-platform\movie-rating-platform directory**
- **Inside movie-rating-platform\movie-rating-platform, open a terminal and run the command docker compose up --build, then wait for all services to successfully build**

## Running the Application
- **After the build is complete, access the application at: http://localhost:4200**

## Bugfixes & Updates
##  Search Fixes
- **Fixed: Search now correctly returns an empty list when no movie/TV show matches the entered query (previously all items were displayed).**
- **Fixed: 4 stars and at least 4 stars in smart search now return different results, as expected.**

## Added a login screen with a Login button.
- **Hardcoded demo user credentials:**  
  **Username:** `demo`  
  **Password:** `password123`
- **After successful authentication, the user gains access to the authorized API endpoint /actor, which returns a list of actors.**
- **If the user is not authenticated, the API returns `401 Unauthorized`.**
- **GET APIs for Movies/TV Shows, as well as POST for rating submissions, are whitelisted and can be accessed without authentication.**

# Technologies Used
- **ASP.NET Core 8 – for building the REST API**
- **Entity Framework Core – for database access**
- **SQL Server – as the database management system**
- **Angular – for developing the web application**

# Deployment i Hosting
- **Docker**
- **.env konfiguracija – for database parameters, ports, and security-related settings**
- **SQL Server – as the database management system**
- **NGINX – used as a web server for hosting the Angular application in a production environment**


