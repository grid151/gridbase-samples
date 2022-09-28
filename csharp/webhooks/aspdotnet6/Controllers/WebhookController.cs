using System.Text;
using GridBaseWebhookExample.Models;
using GridBaseWebhookExample.Webhooks;
using Microsoft.AspNetCore.Mvc;

namespace GridBaseWebhookExample.Controllers;

/// <summary>Sample controller for receiving web hook calls/notifications from GridBase</summary>
[ApiController]
[Route("[controller]")]
public class WebhookController : ControllerBase
{
    #region Members and Constructors
    private readonly ILogger<WebhookController> _logger;

    /// <summary>Creates a new <see cref="WebhookController"/></summary>
    /// <param name="logger">The <see cref="ILogger"/> object used for logging, tracing</param>
    public WebhookController(ILogger<WebhookController> logger)
    {
        _logger = logger;
    }
    #endregion

    #region Web Hook Endpoints / Methods
    [HttpPut]
    [Route("OrderPlaced")]
    public IActionResult OrderPlaced(OrderPlacedData input)
    {
        //TODO: Update the second argument when calling VerifySignature to match the Secret Key configured for this endpoint in GridBase / Developer / Web Hooks
        if (!VerifySignature(input, "********************************************"))
        {
            return Unauthorized();
        }

        //TODO: Add your business logic here.

        return Ok("Success");
    }

    /// <summary>Called by GridBase when a action is triggered on an order.</summary>
    /// <param name="input">Object containing information about the action which was triggered.</param>
    /// <returns>Returns a string indicating success when the call completes without issue</returns>
    [HttpPut]
    [Route("OrderAction")]
    public IActionResult OrderAction(OrderActionData input)
    {
        try
        {
            //TODO: Update the second argument when calling VerifySignature to match the Secret Key configured for this endpoint in GridBase / Developer / Web Hooks
            if (!VerifySignature(input, "********************************************"))
            {
                return Unauthorized();
            }

            //TODO: Add your business logic here.

            return Ok("Success");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            throw;
        }
    }

    /// <summary>Called by GridBase when a new note is added to an order.</summary>
    /// <param name="input">Object containing information about the note added.</param>
    /// <returns>Returns a string indicating success when the call completes without issue</returns>
    [HttpPut]
    [Route("OrderNote")]
    public IActionResult OrderNote(OrderNoteData input)
    {
        try
        {
            //TODO: Update the second argument when calling VerifySignature to match the Secret Key configured for this endpoint in GridBase / Developer / Web Hooks
            if (!VerifySignature(input, "********************************************"))
            {
                return Unauthorized();
            }

            //TODO: Add your business logic here.

            return Ok("Success");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            throw;
        }
    }

    /// <summary>Called by GridBase when a new document is added to an order.</summary>
    /// <param name="input">Object containing information about the document added.</param>
    /// <returns>Returns a string indicating success when the call completes without issue</returns>
    [HttpPut]
    [Route("OrderDocument")]
    public IActionResult OrderDocument(OrderDocumentAddedData input)
    {
        try
        {
            //TODO: Update the second argument when calling VerifySignature to match the Secret Key configured for this endpoint in GridBase / Developer / Web Hooks
            if (!VerifySignature(input, "********************************************"))
            {
                return Unauthorized();
            }

            //TODO: Add your business logic here.

            return Ok("Success");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            throw;
        }
    }
    #endregion

    #region Private Helper Methods
    /// <summary>Verifies a signature for an incoming web hook request.</summary>
    /// <typeparam name="T">The input type.</typeparam>
    /// <param name="input">The input object.</param>
    /// <param name="secretKey">The secret key configured in GridBase / Developers / Web Hooks</param>
    /// <returns>Returns true when the signature is valid.</returns>
    private bool VerifySignature<T>(T input, string secretKey)
    {
        var endpoint = new StringBuilder();
#if DEBUG
        //Only allow use of plain-text HTTP transmission for debugging locally. ALWAYS require HTTPS for production!!!
        endpoint.AppendFormat("{0}{1}", Request.IsHttps ? "https://" : "http://", Request.Host);
#else
        endpoint.AppendFormat("https://{0}", Request.Host);
#endif
        endpoint.Append(Request.Path);

        return new WebHookSignature<T>
        {
            SecretKey = secretKey,
            Input = input,
            Endpoint = endpoint.ToString()
        }.Verify(Request.Headers["X-GridBase-Signature"]);
    }
    #endregion
}
