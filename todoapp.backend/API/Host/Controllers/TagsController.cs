using Application.Handlers.Tags;
using Azure.Security.KeyVault.Secrets;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Host.Controllers;

public class TagsController(ISender mediator, SecretClient secretClient) : VersionedApiController
{
    [HttpGet()]
    public async Task<IActionResult> GetTagsAsync([FromQuery] string key)
    {
        Console.WriteLine(JsonSerializer.Serialize(secretClient.GetSecret(key)));
        return Ok(await mediator.Send(new GetTagsRequest()));
    }
}