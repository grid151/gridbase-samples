namespace GridBaseWebhookExample.Webhooks;

/// <summary>Supported signature versions.</summary>
/// <remarks>
/// <para>
/// This is used for future-proofing things. As cryptographic algorithms and key sizes
/// typically need to beg updated after some years or decades (depending), it's normal
/// to have to upgrade things to use stronger key sizes and/or ciphers.
/// </para>
/// </remarks>
public enum WebHookSignatureVersion
{
    /// <summary>Version 1 of digital signature generation and verification.</summary>
    Version1 = 1
}

