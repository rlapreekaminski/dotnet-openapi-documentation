
public static class SessionEndpoints
{
    public static RouteGroupBuilder MapSessions(this RouteGroupBuilder group)
    {
        group.MapGet("/", () => GetSessions())
            .Produces<Session>(StatusCodes.Status200OK)
            .WithSummary("Get all sessions")
            .WithDescription("Retrieves all sessions from the database.")
            .WithName(nameof(GetSessions));

        group.MapGet("/{id}", (Guid id) => GetSession(id))
            .WithSummary("Get a session by ID")
            .WithDescription("Retrieves a session from the database by its ID.")
            .WithName(nameof(GetSession))
            .Produces<Session>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", (Session session) => CreateSession(session))
            .WithSummary("Create a new session")
            .WithDescription("Adds a new session to the database.")
            .WithName(nameof(CreateSession))
            .Produces<Session>(StatusCodes.Status201Created);

        group.MapPut("/{id}", (Guid id, Session sessionUpdated) => UpdateSession(id, sessionUpdated))
            .WithSummary("Update a session by ID")
            .WithDescription("Updates a session in the database by its ID.")
            .WithName(nameof(UpdateSession))
            .Produces<Session>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound); ;

        group.MapDelete("/{id}", (Guid id) => DeleteSession(id))
            .WithSummary("Delete a session by ID")
            .WithDescription("Deletes a session from the database by its ID.")
            .WithName(nameof(DeleteSession))
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound); ;

        return group;
    }

    private static IResult GetSessions() => Results.Ok(LocalDB.Sessions);

    private static IResult GetSession(Guid sessionId) => LocalDB.Sessions.FirstOrDefault(u => u.Id == sessionId) is Session session ? Results.Ok(session) : Results.NotFound();

    private static IResult CreateSession(Session session)
    {
        LocalDB.Sessions.Add(session);
        return Results.Created($"/sessions/{session.Id}", session);
    }

    private static IResult UpdateSession(Guid sessionId, Session sessionUpdated)
    {
        Session? session = LocalDB.Sessions.FirstOrDefault(u => u.Id == sessionId);

        if (session == null)
            return Results.NotFound();

        LocalDB.Sessions.Remove(session);
        LocalDB.Sessions.Add(sessionUpdated);

        return Results.Ok(sessionUpdated);
    }

    private static IResult DeleteSession(Guid sessionId)
    {
        Session? session = LocalDB.Sessions.FirstOrDefault(u => u.Id == sessionId);

        if (session == null)
            return Results.NotFound();

        LocalDB.Sessions.Remove(session);

        return Results.NoContent();
    }
}