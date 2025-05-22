using Example.Types;

namespace Example;

public static class UserRepository
{
    public static User[] GetUsers()
    {
        return
        [
            new User { Id = 1, Name = "John Doe" },
            new User { Id = 2, Name = "Jane Doe" },
            new User { Id = 3, Name = "Sam Smith" },
            new User { Id = 4, Name = "Alice Johnson" },
            new User { Id = 5, Name = "Bob Brown" }
        ];
    }
}

public static class PostRepository
{
    public static Post[] GetPosts()
    {
        return
        [
            new Post { Id = 1, Title = "Post 1", Content = "Content 1", AuthorId = 1 },
            new Post { Id = 2, Title = "Post 2", Content = "Content 2", AuthorId = 2 },
            new Post { Id = 3, Title = "Post 3", Content = "Content 3", AuthorId = 2 },
            new Post { Id = 4, Title = "Post 4", Content = "Content 4", AuthorId = 4 },
            new Post { Id = 5, Title = "Post 5", Content = "Content 5", AuthorId = 5 }
        ];
    }
}
