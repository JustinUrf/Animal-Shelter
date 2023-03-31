## Animal Shelter

#### Justin Lee

#### An API for a fictional Animal Shelter that houses cats and dogs.

## Technologies Used

* C#
* .NET
* ASP.Net
* Entity Framework

## Description

An API that contains details for a shelter that contains cats and dogs.


### Set Up and Run Project

1. Clone this repo.
2. Open the terminal and navigate to this project's production directory called "Animal Shelter".
3. Within the production directory "Animal", create two new files: ``appsettings.json`` and ``appsettings.Development.json``.
4. Within ``appsettings.json``, put in the following code. Make sure to replacing the ``uid`` and ``pwd`` values in the MySQL database connection string with your own username and password for MySQL.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[Your_database_name_here];uid=[Your_User_Id_Here];pwd=[Your_Pass_word_here];"
  }
}
```

5. Within `appsettings.Development.json`, add the following code:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

6. Create the database using the migrations in the Animal Shelter API project. Open your shell (e.g., Terminal or GitBash) to the production directory "AnimalShelter", and run `dotnet ef database update`. This works because the "Migrations" folder comes with the project. 
7. Within the production directory "AnimalShelter", run ``dotnet watch run``
8. To optionally further build out this project in development mode, start the project with `dotnet watch run` in the production directory "AnimalShelter".
9. Use your program of choice to make API calls. In your API calls, use the domain _http://localhost:5000_.

## Testing the API Endpoints

You are welcome to test this API via [Postman](https://www.postman.com/).


### Available Endpoints

```
GET http://localhost:5000/api/animals/page/{page} 
GET http://localhost:5000/api/animals/
GET http://localhost:5000/api/animals/{id}
POST http://localhost:5000/api/animals/
PUT http://localhost:5000/api/animals/{id}
DELETE http://localhost:5000/api/animals/{id}
```

Note: `{id}` is a variable and it should be replaced with the id number of the animal you want to GET, PUT, or DELETE.
Additionally for paginated list of Animals, use the .../animals/page/{page} to see 2 animals at a time. `{page}` is this is also a variable and should be replaced on the page that you would like to view.

#### Optional Query String Parameters for GET Request

GET requests to `http://localhost:5000/api/animals/` can optionally include query strings to filter or search animals. For example:

| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- |
| name        | String      | not required | Returns animals with a matching name value |
| age         | Number      | not required | Returns animals with a matching age value |


These can be done with all the properties inside of the Animal.cs models file including age, name, gender, breed, color and color. See examples below.
The following query will return all animals with the name "Hero":

```
GET http://localhost:5000/api/animals?name=Hero
```

You can include multiple query strings by separating them with an `&`:

```
GET http://localhost:5000/api/animals?name=hero&age=13
```

#### Additional Requirements for POST Request

When making a POST request to `http://localhost:5000/api/animals/`, you need to include a **body**. Here's an example body in JSON:

```json
{
  "name": "Hero",
  "age": 10,
  "color": "Tan",
  "breed": "Dog",
  "gender": "Male"
}
```

#### Additional Requirements for PUT Request

When making a PUT request to `http://localhost:5000/api/animals/{id}`, you need to include a **body** that includes the animals's `animalId` property. Here's an example body in JSON:

```json
{
  "AnimalId": 1,
  "name": "Hero",
  "age": 10,
  "color": "Tan",
  "breed": "Dog",
  "gender": "Male"
}
```

And here's the PUT request we would send the previous body to:

```
http://localhost:5000/api/animal/1
```

Notice that the value of `animalId` needs to match the id number in the URL. In this example, they are both 1.

## Known Bugs

* No known issues.

## License
Enjoy the API!

[MIT](https://github.com/git/git-scm.com/blob/main/MIT-LICENSE.txt)

Copyright (c) 2023 Justin Lee 