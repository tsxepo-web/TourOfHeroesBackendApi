<h1 align="center">Welcome to TourOfHeroesBackendApi 👋</h1>
<p>
</p>

The project uses layered architecture design. Refer to [TourOfHeroes-Architecture](https://github.com/tsxepo-web/TourOfHeroesBackendApi/blob/master/TourOfHeroesArch.drawio.png) for a visual design.

## About the project
This project is created for a simple Hero vs Villain game.
You choose a Hero, Villain and City. The temperature of the city will be used to score the characters based on their powers.

## Database Layer
Copy the bellow to install packages used in this layer:
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package MongoDB.Driver
```

### Business Logic Layer
Copy the bellow To install packages used in this layer:
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.Extensions.Http
dotnet add package Microsoft.Extensions.Options
dotnet add package Newtonsoft.Json
```

## Interfaces
IheroRepository for the databases.
IweatherService for the weather services.

## Presentation Layer UI
Angular is used for the front end.

## Cloud
Azure Static Web App is used to host the frontend.
Azure App Services is used to host the backend.
Azure Cosmos DB is used to host data.
Github Workflows is used for CI/CD and Actions to track the deployments. 


## Author

👤 **tsxepo**

* Github: [@tsxepo-web](https://github.com/tsxepo-web)
* Backend Url: [HeroesApi](https://tourofheroesbackendtjabane.azurewebsites.net/api/heroes)
* Frontend Url: [TourOfHeroes](https://salmon-tree-09b222d00.2.azurestaticapps.net/dashboard)

## Show your support

Give a ⭐️ if this project helped you!

***
_This README was generated with ❤️ by [readme-md-generator](https://github.com/kefranabg/readme-md-generator)_