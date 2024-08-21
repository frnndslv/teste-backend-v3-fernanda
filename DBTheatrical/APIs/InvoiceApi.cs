
using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public static class InvoiceApi
{

    public static void MapInvoiceApi(this WebApplication app)
    {

        var group = app.MapGroup("/invoice");


        group.MapGet("/", async (TheatricalPlayersRefactoringKataContext db) =>
            await db.Invoice.ToListAsync()
        );

        group.MapPost("/", async (Invoice invoice, TheatricalPlayersRefactoringKataContext db) =>
        {
            db.Invoice.Add(invoice);
            await db.SaveChangesAsync();

            return Results.Created($"/invoice/{invoice.Id}", invoice);
        }
        );

        group.MapPut("/{id}", async (int id, Invoice invoiceAlterado, TheatricalPlayersRefactoringKataContext db) =>
        {
            var invoice = await db.Invoice.FindAsync(id);
            if (invoice is null)
            {
                return Results.NotFound();
            }

            invoice.Customer = invoiceAlterado.Customer ?? invoice.Customer;
            invoice.Performances = invoiceAlterado.Performances ?? invoice.Performances;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }
        );

        group.MapDelete("/{id}", async (int id, TheatricalPlayersRefactoringKataContext db) =>
        {
            if (await db.Invoice.FindAsync(id) is Invoice invoice)
            {
                db.Invoice.Remove(invoice);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
        );
    }
}