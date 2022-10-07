# Selfie à Wookie API

Formation suivie : https://www.udemy.com/course/maitriser-web-api-rest-avec-aspnet-core-dotnet-50-full
 
Pour effectuer une migration :

- Créez la BDD sur SSMS : SelfiesAWookies.Database.dev
- Allez dans le projet "Infrastructures"
- Tapez la commande suivante : dotnet ef migrations add InitDatabase --project=..\SelfieAWookie.Core.Selfies.Data.Migrations
- Puis tapez : dotnet ef database update

ça y est la BDD à été migrée !