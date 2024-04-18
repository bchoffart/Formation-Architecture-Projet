
# 1. Migration et création de la base de données depuis les models

**Installation de l'outil dotnet-ef pour gérer les migrations et mettre à jour la base de données.**

    dotnet tool install --global dotnet-ef

**Ajout du package Microsoft.EntityFrameworkCore.Design pour pouvoir utiliser les outils de migrations.**

    dotnet add package Microsoft.EntityFrameworkCore.Design

**Création de migrations**

    dotnet ef migrations add InitialCreate

**Application des migrations à la base de données**

    dotnet ef database update

# 2. Import du fichier `.json` fourni sur Postman, il possède les requêtes nécessaires au test de l'application.

# 3. Manipulation de l'application

## Etape 1 : Enregistrement d'un compte

Utilisez la route POST register pour créer votre compte, un body est prédifini mais il est possible de le modifier pour tester.

## Etape 2 : Remplissage de la base de données

Sur PostMan, dans la section Rooms -> Admin, vous retrouverez la route GET create Rooms, il suffit d'appuyer sur send pour créer 3 Rooms en base de données.

## Etape 3 : Manipulation des données

Une fois que la base de données est remplie, vous pourrez tester les différentes requêtes. Les tokens des rôles sont déjà définis dans les requêtes, vous pouvez les modifier pour tester la gestion des erreurs quant aux rôles.
