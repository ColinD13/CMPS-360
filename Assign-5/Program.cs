
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Sample NFL Teams
List<Team> teams = new List<Team>
{
    new Team { TeamId = 1, State = "Pennsylvania", City = "Pittsburgh", Wins = 8, Losses = 2, Name = "Steelers" },
    new Team { TeamId = 2, State = "Maryland", City = "Baltimore", Wins = 7, Losses = 3, Name = "Ravens" },
    new Team { TeamId = 3, State = "Ohio", City = "Cleveland", Wins = 3, Losses = 7, Name = "Browns" },
    new Team { TeamId = 4, State = "Ohio", City = "Cincinnati", Wins = 5, Losses = 5, Name = "Bengals" },
    new Team { TeamId = 5, State = "New York", City = "Buffalo", Wins = 7, Losses = 3, Name = "Bills" }
};

// GET all teams
app.MapGet("/teams", () =>
{
    return Results.Ok(teams);
});

// GET team by ID
app.MapGet("/teams/{id:int}", (int id) =>
{
    var team = teams.FirstOrDefault(t => t.TeamId == id);

    if (team == null)
        return Results.NotFound();

    return Results.Ok(team);
});

// POST new team
app.MapPost("/teams", (Team team) =>
{
    if (string.IsNullOrWhiteSpace(team.Name) ||
        string.IsNullOrWhiteSpace(team.City) ||
        string.IsNullOrWhiteSpace(team.State) ||
        team.Wins < 0 || team.Losses < 0)
    {
        return Results.BadRequest("Invalid team information");
    }

    team.TeamId = teams.Max(t => t.TeamId) + 1;

    teams.Add(team);

    return Results.Created($"/teams/{team.TeamId}", team);
});

// PUT update team
app.MapPut("/teams/{id:int}", (int id, Team updatedTeam) =>
{
    var team = teams.FirstOrDefault(t => t.TeamId == id);

    if (team == null)
        return Results.NotFound();

    if (string.IsNullOrWhiteSpace(updatedTeam.Name) ||
        string.IsNullOrWhiteSpace(updatedTeam.City) ||
        string.IsNullOrWhiteSpace(updatedTeam.State) ||
        updatedTeam.Wins < 0 || updatedTeam.Losses < 0)
    {
        return Results.BadRequest("Invalid team information");
    }

    team.Name = updatedTeam.Name;
    team.City = updatedTeam.City;
    team.State = updatedTeam.State;
    team.Wins = updatedTeam.Wins;
    team.Losses = updatedTeam.Losses;

    return Results.Ok(team);
});

// DELETE team
app.MapDelete("/teams/{id:int}", (int id) =>
{
    var team = teams.FirstOrDefault(t => t.TeamId == id);

    if (team == null)
        return Results.NotFound();

    teams.Remove(team);

    return Results.NoContent();
});

// GET teams by state using LINQ
app.MapGet("/teams/state/{state}", (string state) =>
{
    var filteredTeams = teams
        .Where(t => t.State.Equals(state, StringComparison.OrdinalIgnoreCase))
        .ToList();

    return Results.Ok(filteredTeams);
});

app.Run();
