using System.Runtime.Serialization;

namespace GridBaseWebhookExample.Models;

/// <summary>Data results from OrderDocumentAdded web hook event</summary>
public class OrderDocumentAddedData
{
    /// <summary>GridBase Order ID</summary>
    public string OrderId { get; set; } = string.Empty;
    /// <summary>Documents array</summary>
    public List<DocumentData>? Documents { get; set; }
}

/// <summary>Document results from OrderNoteAdded web hook event</summary>
public class DocumentData
{
    /// <summary>GridBase document id</summary>
    public string? Id { get; set; }
    /// <summary>File name.</summary>
    public string? FileName { get; set; }
}
