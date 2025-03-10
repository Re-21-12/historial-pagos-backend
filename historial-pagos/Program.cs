using Microsoft.EntityFrameworkCore;
using System;
using historial_pagos;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddServices();
var connectionString = builder.Configuration.GetConnectionString("SQLiteConnection") ?? "Data Source=historial-pagos.db";
builder.Services.AddSqlite<AppDbContext>(connectionString);

// Configurar la aplicación
var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints(); // Mapear los endpoints

app.Run();