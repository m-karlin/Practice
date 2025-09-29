using App.Algorithms;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/Algorithms/BinarySearch", ([FromBody] BinarySearchRequest request) => BinarySearch.Search(request.Numbers, request.Target))
	.WithName("BinarySearch");

app.Run();

public record BinarySearchRequest(int[] Numbers, int Target);