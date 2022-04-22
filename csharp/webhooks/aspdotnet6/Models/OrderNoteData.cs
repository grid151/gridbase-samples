namespace GridBaseWebhookExample.Models;

/// <summary>Data results from OrderNoteAdded web hook event</summary>
public class OrderNoteData
{
    //// <summary>GridBase Order ID</summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>Client's file number</summary>
    public string ClientFileNumber { get; set; } = string.Empty;
    
    /// <summary>Notes subject</summary>
    public string? NoteSubject { get; set; }
    
    /// <summary>Notes body</summary>
    public string? NoteBody { get; set; }
}
