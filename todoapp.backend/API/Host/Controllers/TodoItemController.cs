using Application.Handlers.TodoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

public class TodoItemController(ISender mediator) : VersionedApiController
{

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<Guid> DeleteTodoItemById(Guid id)
    {
        return await mediator.Send(new DeleteTodoItemRequest(id));
    }
}
