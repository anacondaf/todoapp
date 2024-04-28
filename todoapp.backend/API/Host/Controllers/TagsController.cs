using Application.Handlers.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

public class TagsController(ISender mediator) : BaseApi
{
    [HttpGet]
    public async Task<IActionResult> GetTagsAsync()
    {
        return Ok(await mediator.Send(new GetTagsRequest()));
    }
}