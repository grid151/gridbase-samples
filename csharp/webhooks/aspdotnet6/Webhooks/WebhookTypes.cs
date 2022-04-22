namespace GridBaseWebhookExample.Webhooks;

/// <summary>Supported web hook types.</summary>
public enum WebHookTypes
{
    /// <summary>An action was triggered on an order.</summary>
    OrderAction = 110,
    /// <summary>A note was added to an order.</summary>
    OrderNoteAdded = 120,
    /// <summary>A document was added to an order.</summary>
    OrderDocumentAdded = 130
}
