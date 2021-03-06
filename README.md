# Custom Exception Middleware

## Install

- ### Package Manager Console

```
Install-Package CustomExceptionMiddleware
```

- ### .Net CLI

```
dotnet add package CustomExceptionMiddleware
```

### Minimum requirements to use: [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

### Compilation requirements: [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

## How to use

It's very simple to use, go to `Startup.cs` on `Configure()` method and add this code:

```c#
app.UseCustomExceptionMiddleware();
```

Example output    
```
{
    "ErrorMessage": "Custom not found exception message"
}
```

### Custom use
1. Create object options <br/>
It's possible create a `CustomExceptionOptions` to customize the return middleware object, to create this options add this:

    ```c#
    app.UseCustomExceptionMiddleware(new CustomExceptionOptions
    {
        CustomErrorModel = new
        {
            Success = false
            Type = "ErrorType"
        }
    });
    ```

    Example output
    ```
    {
        "Type": "TestType",
        "Success": false,
        "ErrorMessage": "Custom not found exception message"
    }
    ```

2. Use an action options <br/>
Other options to customize the return object is using an action to create a `CustomErrorModel`
    ```c#
    app.UseCustomExceptionMiddleware(options =>
    {
        options.CustomErrorModel = new
        {
            Success = false
            Type = "ErrorType"
        };
    });
    ```

    Example output
    ```
    {
        "Type": "TestType",
        "Success": false,
        "ErrorMessage": "Custom not found exception message"
    }
    ```

### Configure Exceptions
This middleware use some custom exceptions to catch and personalize the response status code.

The custom middleware supports the following **Exceptions**:

| Exception             | Status code description | Status code |
|-----------------------|-------------------------|-------------|
| DomainException       | BadRequest              | 400         |
| CannotAccessException | Forbidden               | 403         |
| NotFoundException     | NotFound                | 404         |
| Exception             | InternalServerError     | 500         |

`DomainException` is an abstract exception, so to use it's necessary create other exception and inherit. The others exceptions only throw an exception

#### Custom exception example
```c#
public class InvalidStateException : DomainException
{
    public InvalidStateException(string message) : base(message)
    { }
}
```    

#### Throw exceptions
```c#
throw new InvalidStateException("Custom domain exception message");
throw new CannotAccessException("Custom cannot access exception message");
throw new NotFoundException("Custom not found exception message");
throw new Exception("Custom exception message");
```