using historial_pagos;
using historial_pagos.Models;
using Microsoft.EntityFrameworkCore;

public static class Endpoints
{
    public static void MapEndpoints(this WebApplication app)
    {

        app.MapGet("/test-connection", async (AppDbContext dbContext) =>
        {
            try
            {
                var result = await dbContext.Pago.FirstOrDefaultAsync(); // Cambia 'Pago' por tu tabla
                if (result != null)
                {
                    return Results.Ok("Conexión exitosa a la base de datos.");
                }
                return Results.Ok("La base de datos está conectada, pero no hay registros.");
            }
            catch (Exception ex)
            {
                // Devolver el código 500 con un mensaje de error
                return Results.Problem($"Error al conectar con la base de datos: {ex.Message}", statusCode: 500);
            }
        });





        app.MapGet("/Payments", async (AppDbContext db) => {
            return await db.Pago.ToListAsync();
        })
            .WithName("GetPayments")
            .WithOpenApi();

        app.MapPost("/Payments", async (AppDbContext db, Pago pago) => {
            db.Pago.Add(pago);
            await db.SaveChangesAsync();
            return Results.Created($"/Payments/{pago.Id}", pago);
        })
            .WithName("CreatePayment")
            .WithOpenApi();

    }
}

