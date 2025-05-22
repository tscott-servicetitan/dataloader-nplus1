# Resolver Serial Execution

This project demonstrates N+1 query issues when the resolver execution strategy
is set to `Serial`.

## About the Project

### Types

There are two types defined. These types are [User](./src/Example/Types/User.cs) and [Post](./src/Example/Types/Post.cs). A user has many posts
and a post belongs to an author (User).


### Flipping between Serial and Parallel

In [Program.cs](./src/Example/Program.cs) we can toggle between serial and parallel
execution strategies.

## Recreate N+1

Run the project with the debugger attached and a breakpoint within the
[UserDataLoader.GetUsersAsync method](./src/Example/DataLoaders.cs).

Now run the following query:

```graphql
query {
    posts {
        author {
            id
        }
    }
}
```

We are asking for all posts and for each post, the author id. The
expected behavior is that rather than executing a query for each post
to fetch the author, we should fetch all authors in a batch.

You can observe actual behavior when the breakpoint is hit. If method 
is executed multiple times in one request, then there is an N+1 issue.
In this event, you'll notice that when the method is called, it is passing
a single id at a time.

## Fix N+1

Now within [Program.cs](./src/Example/Program.cs), change `ExecutionStrategy.Serial`
to `ExecutionStrategy.Parallel`. Now repeat the [Recreation step](#recreate-n1) except
that this time, you should only observe the dataloader being executed once.


## Helpful Links

* [HotChocolate DataLoader Documentation](https://chillicream.com/docs/hotchocolate/v15/fetching-data/dataloader)
* [DataLoader LoadAsync Implementation](https://github.com/ChilliCream/graphql-platform/blob/main/src/GreenDonut/src/GreenDonut/DataLoaderBase.cs#L107)
