using BS_Proj;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PlayerDB>(opt => opt.UseInMemoryDatabase("PlayerList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/Players", async (PlayerDB db) =>
    await db.Players.ToListAsync());

app.MapGet("/Players/{id:int}", async (int id, PlayerDB db) =>
    await db.Players.FindAsync(id)
        is Player Player
            ? Results.Ok(Player)
            : Results.NotFound());

app.MapGet("/Players/name/{id:int}", async (int id, PlayerDB db) =>
    await db.Players.FindAsync(id)
        is Player Player
            ? Results.Ok(Player.Name)
            : Results.NotFound());
app.MapGet("/Players/age/{id:int}", async (int id, PlayerDB db) =>
    await db.Players.FindAsync(id)
        is Player Player
            ? Results.Ok(Player.Age)
            : Results.NotFound());
app.MapGet("/Players/height/{id:int}", async (int id, PlayerDB db) =>
    await db.Players.FindAsync(id)
        is Player Player
            ? Results.Ok(Player.Height)
            : Results.NotFound());
app.MapGet("/Players/team/{id:int}", async (int id, PlayerDB db) =>
    await db.Players.FindAsync(id)
        is Player Player
            ? Results.Ok(Player.Team)
            : Results.NotFound());

app.MapGet("/Players/team/{teamName}", async (string teamName, PlayerDB db) =>
    await db.Players.Where(t => t.Team == teamName).ToListAsync());

app.MapPost("/Players", async (Player Player, PlayerDB db) =>
{
    db.Players.Add(Player);
    await db.SaveChangesAsync();

    return Results.Created($"/Playeritems/{Player.Id}", Player);
});

app.MapPut("/Players/{id:int}", async (int id, Player inputPlayer, PlayerDB db) =>
{
    var Player = await db.Players.FindAsync(id);

    if (Player is null) return Results.NotFound();

    Player.Name = inputPlayer.Name;
    Player.Age = inputPlayer.Age;
    Player.Height = inputPlayer.Height;
    Player.Team = inputPlayer.Team;

    await db.SaveChangesAsync();

    return Results.Ok(Player);
});

app.MapPut("/Players/removeFromTeam/{id:int}", async (int id, PlayerDB db) =>
{
    var Player = await db.Players.FindAsync(id);

    if (Player is null) return Results.NotFound();

    Player.Team = "No Team";

    await db.SaveChangesAsync();

    return Results.Ok(Player);
});

app.MapPut("/Players/setTeam/{id:int}/{teamName}", async (int id, string teamName, PlayerDB db) =>
{
    var Player = await db.Players.FindAsync(id);

    if (Player is null) return Results.NotFound();

    Player.Team = teamName;

    await db.SaveChangesAsync();

    return Results.Ok(Player);
});

app.MapDelete("/Players/{id}", async (int id, PlayerDB db) =>
{
    if (await db.Players.FindAsync(id) is Player Player)
    {
        db.Players.Remove(Player);
        await db.SaveChangesAsync();
        return Results.Ok(Player);
    }

    return Results.NotFound();
});

app.Run();