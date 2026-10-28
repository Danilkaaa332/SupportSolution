using Support.Application;
using Support.Domain;
using Support.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITicketRepository, InMemoryTicketRepository>();

var app = builder.Build();

app.MapPost("/tickets", async (
    CreateTicketRequest request,
    ITicketRepository repository,
    CancellationToken cancellationToken) =>
{
    if (string.IsNullOrWhiteSpace(request.Title))
        return Results.BadRequest(new { error = "Заголовок обязателен." });

    var ticket = new SupportTicket(Guid.NewGuid(), request.Title);
    await repository.SaveAsync(ticket, cancellationToken);

    return Results.Created($"/tickets/{ticket.Id}", new
    {
        ticket.Id,
        ticket.Title,
        Status = ticket.Status.ToString()
    });
});

app.MapGet("/tickets/{id:guid}", async (
    Guid id,
    ITicketRepository repository,
    CancellationToken cancellationToken) =>
{
    var ticket = await repository.GetAsync(id, cancellationToken);

    return ticket is null
        ? Results.NotFound()
        : Results.Ok(new
        {
            ticket.Id,
            ticket.Title,
            Status = ticket.Status.ToString()
        });
});

app.Run();

public sealed record CreateTicketRequest(string Title);
