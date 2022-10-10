# Selfie à Wookie API

Formation suivie : https://www.udemy.com/course/maitriser-web-api-rest-avec-aspnet-core-dotnet-50-full
 
Pour effectuer une migration :

- Créez la BDD sur SSMS : SelfiesAWookies.Database.dev
- Allez dans le projet "Infrastructures" puis mettez vous dans le Powershell (click droit -> Ouvrir le terminal)
- Puis tapez : dotnet ef database update --startup-project . --project=..\SelfieAWookie.Core.Selfies.Data.Migrations

- Si vous souhaitez ajouter une nouvelle version de migration tapez : dotnet ef migrations add NewTableExample --startup-project . --project=..\SelfieAWookie.Core.Selfies.Data.Migrations
- Régénerez le projet "Migrations" puis réexectuez une update

ça y est la BDD à été migrée !