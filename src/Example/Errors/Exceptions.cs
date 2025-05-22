namespace Example.Errors;

public class MyException(string? message = null) : Exception(message ?? "Hello World Exception");
