# BeyondSports Assignment

In this repo you can find all you need to run and test the code. 

First you will need to download the Visual Studio project "BS Project".
Next, you need to download the Postman request collection "New Collection.postman_collection"
Inside the collection you will find Postman requests for different scenraios.

First we need to add some entries to the database. To do so, we can use the 6 POST requests. Each will add a new player to the database.
To pass a new player entry you will need to post on the link: https://localhost:7067/players
The body has to be a JSON file with the following tempalte:
{
    "name": string,
    "age": int,
    "height": int,
    "team": string
}

Next we can get a list of all the players and their respective data, by using the "Get All Players" or sending a GET request on the link: https://localhost:7067/players

We also can get all the players from a specific team by sending a GET request on the link: https://localhost:7067/players/team/{teamName}
where "teamName" is the string of the team you want. Example requests are "Get All From Team Zimbru" and "Get All From Team Juventus".

We can also get a player specific data from ID, such as name, age, team and height. To do that, we need to send a GET request to one of the according links:
https://localhost:7067/players/name/{id}
https://localhost:7067/players/age/{id}
https://localhost:7067/players/height/{id}
https://localhost:7067/players/team/{id}
, where {id} is the id of the desired player.

In order to update an existing index with a different player' data, we have to send a PUT request to the link: https://localhost:7067/players/{id} and with a identical body to the first steps.
{
    "name": string,
    "age": int,
    "height": int,
    "team": string
}
, where {id} is the id of the player you want to override.

Lastly, you can remove a player from a team by calling a PUT request on the link: https://localhost:7067/players/removeFromTeam/{id}.
Once again {id} is the id of the player you want to remove from team. As a result the team field of that player will become "No Team".
And you can change the team of any player by calling the PUT request on the link: https://localhost:7067/players/setTeam/{id}/{teamName}, where {id} is the id of the player you want to add to a team, and {teamName} is the name of that team.
