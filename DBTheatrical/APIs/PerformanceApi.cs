using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


public static class PerformanceApi
{

    public static void MapPerformanceApi(this WebApplication app)
    {

        //tabela
        var group = app.MapGroup("/performance");


        //consultar todos
        group.MapGet("/", async (TheatricalPlayersRefactoringKataContext db) =>
            await db.Performance.ToListAsync()
        );
        //criar um novo
        group.MapPost("/", async (Performance performance, TheatricalPlayersRefactoringKataContext db) =>
        {
            db.Performance.Add(performance);
            await db.SaveChangesAsync();

            return Results.Created($"/performance/{performance.Id}", performance);
        }
        );
        //editar um já existente
        group.MapPut("/{id}", async (int id, Performance performanceAlterado, TheatricalPlayersRefactoringKataContext db) =>
        {
            var performance = await db.Performance.FindAsync(id);
            if (performance is null)
            {
                return Results.NotFound();
            }
            performance.PlayId = performanceAlterado.PlayId ?? performance.PlayId;
            performance.Audience = performanceAlterado.Audience ?? performance.Audience;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }
        );
        //Deletar
        group.MapDelete("/{id}", async (int id, TheatricalPlayersRefactoringKataContext db) =>
        {
            if (await db.Performance.FindAsync(id) is Performance performance)
            {
                db.Performance.Remove(performance);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );
    }
}