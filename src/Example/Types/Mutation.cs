using Example.Errors;

namespace Example.Types;

[MutationType]
public static class Mutation
{
    [UseMutationConvention(PayloadFieldName = "message")]
    public static string HelloWorld(string message)
    {
        return $"Hello, World! {message}";
    }

    [Error<MyArgumentError>]
    public static FieldResult<string> HelloWorldWithErrors(bool throwException = false)
    {
        var rand = new Random();

        try
        {
            if (throwException)
            {
                if (rand.Next(0, 10) % 2 == 0)
                {
                    throw new ArgumentException("Argument Error");
                }

                throw new Exception("Unknown Error");
            }

            return HelloWorld("default");
        }
        catch (ArgumentException e)
        {
            var error = new MyArgumentError();
            return new FieldResult<string>(error);
        }
    }

    // [Error<ArgumentException>]
    // [Error<InvalidOperationException>]
    // [Error<Exception>]
    [Error<HelloWorldErrorFactory>]
    public static FieldResult<string> HelloWorldWithExceptions(bool throwException = false)
    {
        var rand = new Random();

        if (!throwException)
        {
            return HelloWorld("default");
        }

        if (rand.Next(0, 10) % 2 == 0)
        {
            throw new ArgumentException("Argument Error");
        }

        // throw new Exception("Unknown Error");
        throw new InvalidOperationException("Unknown Error");
    }
}

#region Payload Classes

public class MyPayload
{
    public required string Reply { get; set; }
}

#endregion

#region Input Classes

public class MyInput
{
    private bool ThrowException { get; set; }
}
#endregion
