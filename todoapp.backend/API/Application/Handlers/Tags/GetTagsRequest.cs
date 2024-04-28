using MediatR;

namespace Application.Handlers.Tags;

public record TagsResponse(string Name);

public class GetTagsRequest : IRequest<List<TagsResponse>>
{
}

public class GetTagsRequestHandler : IRequestHandler<GetTagsRequest, List<TagsResponse>>
{
    public Task<List<TagsResponse>> Handle(GetTagsRequest request, CancellationToken cancellationToken)
    {
        var tags = new List<TagsResponse>()
        {
            new("1"),
            new("2"),
        };

        return Task.FromResult(tags);
    }
}