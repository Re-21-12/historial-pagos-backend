using historial_pagos;
using historial_pagos.Models;
using Microsoft.EntityFrameworkCore;

public static class Endpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/test-connection",
            async (AppDbContext dbContext) =>
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
                    return Results.Problem(
                        $"Error al conectar con la base de datos: {ex.Message}",
                        statusCode: 500
                    );
                }
            }
        );

        // Endpoint para obtener todos los pagos
        app.MapGet("/Payments", async (AppDbContext db) => await db.Pago.ToListAsync())
            .WithName("GetPayments")
            .WithOpenApi();
        // Endpoint para obtener un pago por su ID
        app.MapPost(
                "/Payments",
                async (AppDbContext db, Pago pago) =>
                {
                    await db.Pago.AddAsync(pago);
                    await db.SaveChangesAsync();
                    return Results.Created($"/Payments/{pago.Id}", pago);
                }
            )
            .WithName("CreatePayment")
            .WithOpenApi();

        // Endpoint para obtener un pago por su ID
        app.MapGet("/Payment", async (AppDbContext db, int Id) => await db.Pago.FindAsync(Id))
            .WithName("GetPayment")
            .WithOpenApi();

        // Endpoint para actualizar un pago por su ID
        app.MapPut(
                "/Payment",
                async (AppDbContext db, int Id, Pago updatedPago) =>
                {
                    var existing = await db.Pago.FindAsync(Id);
                    if (existing is null) return Results.NotFound();
                    
                    existing.Titulo= updatedPago.Titulo;
                    existing.Descripcion= updatedPago.Descripcion;
                    existing.Cantidad= updatedPago.Cantidad;
                    existing.Fecha = updatedPago.Fecha;

                    await db.SaveChangesAsync();
                    return Results.Ok(existing);
                }
            )
            .WithName("UpdatePayment")
            .WithOpenApi();

        // Endpoint para eliminar un pago por su ID
        app.MapDelete("/Payment", async (AppDbContext db, int Id) =>
        {
            var existing = await db.Pago.FindAsync(Id);
            if(existing is null) return Results.NotFound();
            db.Pago.Remove(existing);
            await db.SaveChangesAsync();
            return Results.Ok();
                
        }).WithName("DeletePayment")
            .WithOpenApi();
    }
}
