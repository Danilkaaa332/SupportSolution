namespace Support.Domain;

public sealed class SupportTicket
{
    public Guid Id { get; }
    public string Title { get; private set; }
    public TicketStatus Status { get; private set; }

    public SupportTicket(Guid id, string title)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Идентификатор не может быть пустым.", nameof(id));

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Заголовок обязателен.", nameof(title));

        Id = id;
        Title = title;
        Status = TicketStatus.New;
    }

    public void ChangeStatus(TicketStatus newStatus)
    {
        if (Status == TicketStatus.Closed)
            throw new InvalidOperationException("Закрытую заявку нельзя изменить.");

        if (newStatus == Status)
            throw new InvalidOperationException("Заявка уже находится в этом статусе.");

        Status = newStatus;
    }
}
