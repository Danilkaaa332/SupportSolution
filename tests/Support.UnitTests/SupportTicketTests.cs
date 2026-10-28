using Support.Domain;

namespace Support.UnitTests;

public class SupportTicketTests
{
    [Fact]
    public void ChangeStatus_WhenTicketIsNew_ChangesStatus()
    {
        var ticket = new SupportTicket(Guid.NewGuid(), "Не работает принтер");

        ticket.ChangeStatus(TicketStatus.InProgress);

        Assert.Equal(TicketStatus.InProgress, ticket.Status);
    }

    [Fact]
    public void ChangeStatus_WhenTicketIsClosed_ThrowsException()
    {
        var ticket = new SupportTicket(Guid.NewGuid(), "Не работает принтер");
        ticket.ChangeStatus(TicketStatus.Closed);

        Assert.Throws<InvalidOperationException>(
            () => ticket.ChangeStatus(TicketStatus.InProgress));
    }
}
