namespace Example.Errors;

public abstract class ApplicationErrorFactory
{
    public AppError CreateErrorFrom(Exception exception)
    {
        return new AppError("Something went wrong");
    }
}

public class HelloWorldErrorFactory : ApplicationErrorFactory
{
    public MyArgumentError CreateErrorFrom(ArgumentException exception)
    {
        return new MyArgumentError();
    }
}
