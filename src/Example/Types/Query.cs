namespace Example.Types;

[QueryType]
public static class Query
{
    public static string HelloWorld() => "Hello, World!!!";

    public static IEnumerable<User> GetUsers() => UserRepository.GetUsers();

    public static IEnumerable<Post> GetPosts() => PostRepository.GetPosts();
}
