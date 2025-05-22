namespace Example.Types;

public class Post
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }

    [GraphQLIgnore]
    public long AuthorId { get; set; }

    public async Task<User?> GetAuthorAsync(IUsersDataLoader dataLoader, CancellationToken cancellationToken = default)
    {
        return await dataLoader.LoadAsync(AuthorId, cancellationToken);
    }
}
