using Application.Handlers.Tags;
using Azure.Security.KeyVault.Secrets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

public class TagsController(ISender mediator, SecretClient secretClient) : VersionedApiController
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetTagsAsync([FromQuery] string key)
    {
        return Ok(await mediator.Send(new GetTagsRequest()));
    }
}