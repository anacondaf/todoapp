using Domain.Models;
using MediatR;

namespace Application.Handlers.Tags;

public record TagsResponse(string Name);

public class GetTagsRequest : IRequest<List<Tag>>
{
}

public class GetTagsRequestHandler : IRequestHandler<GetTagsRequest, List<Tag>>
{
    public Task<List<Tag>> Handle(GetTagsRequest request, CancellationToken cancellationToken)
    {
        var tags = new List<Tag>()
        {
           new(),
           new(),
           new(),
        };

        return Task.FromResult(tags);
    }
}