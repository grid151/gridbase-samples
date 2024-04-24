namespace GridBaseWebhookExample.Models;

/// <summary>Model for order placed web hook notifications.</summary>
public class OrderPlacedData
{
    /// <summary>The GridBase Order ID for which placement was attempted.</summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>The outcome of order placement: "success" or "failed"</summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>An optional message further describing or explaining the status.</summary>
    public string Message { get; set; } = string.Empty;
}
