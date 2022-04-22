using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace GridBaseWebhookExample.Webhooks;

/// <summary>Object for cryptographically signing and verifying web hook requests.</summary>
/// <typeparam name="T">The input object type.</typeparam>
public class WebHookSignature<T>
{
    /// <summary>Creates a new web hook signature.</summary>
    #region Constructors

    /// <summary>Creates a new web hook signature object for unit testing.</summary>
    public WebHookSignature() { }

    #endregion

    #region Properties
    /// <summary>The intended end point URL.</summary>
    public virtual string Endpoint { get; set; } = string.Empty;

    /// <summary>The secret key used to generate the signature.</summary>
    public virtual string SecretKey { get; set; } = string.Empty;

    /// <summary>The object containing the body of the web hook request.</summary>
    public virtual T? Input { get; set; } = default;

    /// <summary>The version of the algorithm used for generating and verifying digital signatures.</summary>
    public virtual int SignatureVersion { get; set; } = (int)WebHookSignatureVersion.Version1;
    #endregion

    #region Methods
    /// <summary>Digitally signs a web hook request.</summary>
    /// <returns>Returns a base-64 encoded string containing the signature.</returns>
    /// <exception cref="InvalidDataException">Throws an <see cref="InvalidDataException"/> when input is missing or the algorithm cannot be instantiated.</exception>
    /// <exception cref="NotImplementedException">Throws a <see cref="NotImplementedException"/> when the signature version is not supported.</exception>
    public virtual string Sign()
    {
        if (null == Input)
            throw new InvalidDataException("Cannot generate a signature for an empty web hook request.");

        switch (SignatureVersion)
        {
            //NOTE: new signature versions may be added as additional case statements here in the future.
            case (int)WebHookSignatureVersion.Version1:
                return SignVersion1();
            default:
                throw new NotImplementedException($"{SignatureVersion} is not a supported signature version.");
        }
    }

    /// <summary>Verifies a web hook request's signature.</summary>
    /// <param name="signatureReceived">The signature received from the request's headers.</param>
    /// <returns>Returns true when verification passes.</returns>
    public virtual bool Verify(string signatureReceived)
    {
        return signatureReceived.Equals(Sign(), StringComparison.Ordinal);
    }

    /// <summary>Digitally signs a web hook request.</summary>
    /// <returns>Returns a base-64 encoded string containing the signature.</returns>
    public override string ToString()
    {
        return Sign();
    }
    #endregion

    #region Private Methods
    /// <summary>Generates a version 1 signature.</summary>
    /// <returns>Returns a base-64 encoded string containing the signature.</returns>
    /// <exception cref="InvalidDataException">Throws an <see cref="InvalidDataException"/> when the hash algorithm cannot be instantiated.</exception>
    private string SignVersion1()
    {
        using var alg = KeyedHashAlgorithm.Create("HMACSHA512");
        if (null == alg)
            throw new InvalidDataException("Unable to instantiate hash algorithm.");
        alg.Key = Convert.FromBase64String(SecretKey);
        byte[] input = Encoding.UTF8.GetBytes($"{Endpoint.ToLower()}{JsonConvert.SerializeObject(Input)}");
        return Convert.ToBase64String(alg.ComputeHash(input));
    }
    #endregion
}
