namespace Example.Errors;

public class AppError(string message)
{
    public string Message => message;
}

public class MyArgumentError() : AppError("Invalid Argument");
