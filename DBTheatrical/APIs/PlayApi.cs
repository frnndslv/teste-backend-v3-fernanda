
using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
public static class PlayApi
{

    public static void MapPlayApi(this WebApplication app)
    {

        var group = app.MapGroup("/play");


        group.MapGet("/", async (TheatricalPlayersRefactoringKataContext db) =>
            await db.Play.ToListAsync()
        );

        group.MapPost("/", async (Play play, TheatricalPlayersRefactoringKataContext db) =>
        {
            db.Play.Add(play);
            await db.SaveChangesAsync();

            return Results.Created($"/play/{play.Id}", play);
        }
        );

        group.MapPut("/{id}", async (int id, Play playAlterado, TheatricalPlayersRefactoringKataContext db) =>
        {
            var play = await db.Play.FindAsync(id);
            if (play is null)
            {
                return Results.NotFound();
            }

            play.Name = playAlterado.Name ?? play.Name;
            play.Lines = playAlterado.Lines ?? play.Lines;
            play.Type = playAlterado.Type ?? play.Type;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }
        );

        group.MapDelete("/{id}", async (int id, TheatricalPlayersRefactoringKataContext db) =>
        {
            if (await db.Play.FindAsync(id) is Play play)
            {
                db.Play.Remove(play);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );
    }
}