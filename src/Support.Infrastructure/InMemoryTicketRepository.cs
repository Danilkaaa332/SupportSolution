using System.Collections.Concurrent;
using Support.Application;
using Support.Domain;

namespace Support.Infrastructure;

public sealed class InMemoryTicketRepository : ITicketRepository
{
    private readonly ConcurrentDictionary<Guid, SupportTicket> _tickets = new();

    public Task<SupportTicket?> GetAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _tickets.TryGetValue(id, out var ticket);
        return Task.FromResult(ticket);
    }

    public Task SaveAsync(
        SupportTicket ticket,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _tickets[ticket.Id] = ticket;
        return Task.CompletedTask;
    }
}
