using System.Runtime.Serialization;

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
    /// <summary>GridBase document id</summary>
    public string? Id { get; set; }
    /// <summary>Document type ID.</summary>
    public string? DocumentTypeID { get; set; }
    /// <summary>Document name, results in file name.</summary>
    public string? DocumentName { get; set; }
    /// <summary>Document reason for upload id.</summary>
    public string? DocumentType { get; set; }
    /// <summary>Date time document was added.</summary>
    public DateTime? CreatedDate { get; set; }
    /// <summary>Description</summary>
    public string? Description { get; set; }
    /// <summary>File name.</summary>
    public string? FileName { get; set; }
}
