namespace GridBaseWebhookExample.Models;

/// <summary>Data results from OrderAction webhook event</summary>
public class OrderActionData
{
    /// <summary>GridBase Order ID</summary>
    public string? OrderId { get; set; }
    /// <summary>Client's file number</summary>
    public string? ClientFileNumber { get; set; }
    /// <summary>Action event code</summary>
    public int ActionEventCode { get; set; }
    /// <summary>Action event name</summary>
    public string? ActionEventName { get; set; }
}
