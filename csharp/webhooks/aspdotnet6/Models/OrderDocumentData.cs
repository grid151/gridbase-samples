namespace GridBaseWebhookExample.Models;

/// <summary>Data results from OrderDocumentAdded web hook event</summary>
public class OrderDocumentAddedData
{
    /// <summary>GridBase Order ID</summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>Client's file number</summary>
    public string ClientFileNumber { get; set; } = string.Empty;

    /// <summary>Notes subject</summary>
    public string? NoteSubject { get; set; }

    /// <summary>Notes body</summary>
    public string? NoteBody { get; set; }

    /// <summary>Documents array</summary>
    public List<DocumentData>? Documents { get; set; }
}

/// <summary>Document results from OrderNoteAdded web hook event</summary>
public class DocumentData
{
    /// <summary>Document Type identifier</summary>
    public int DocumentTypeID { get; set; }

    /// <summary>File name of the document</summary>
    public string? DocumentName { get; set; }

    /// <summary>A human-readable description of the document</summary>
    public string? DocumentDescription { get; set; }
}
