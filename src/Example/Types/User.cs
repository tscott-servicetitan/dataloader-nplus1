namespace Example.Types;

public class User
{
    [ID]
    public long Id { get; set; }

    public required string Name { get; set; }

    public IReadOnlyList<Post> GetPosts()
    {
        return PostRepository.GetPosts().Where(p => p.AuthorId == Id).ToList();
    }
}
