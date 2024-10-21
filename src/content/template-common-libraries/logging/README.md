# Template9.Common.Logging

Extensions for configuring logging in using [Serilog](https://serilog.net/).

Serilog has been configured to attach a request ID to all log output that is shared across all log entries for a specific request. This allows for request correlation.

# Extension Method

The following extension methods have been exposed for `WebApplicationBuilder`.

| Method                   | Description                                                     |
|--------------------------|-----------------------------------------------------------------|
| ConfigureStandardLogging | Configures Serilog as the logging provider for the application. |

## Environment Specific Log Levels

In non-development environments, the [log level](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel?view=dotnet-plat-ext-8.0) is set to `Warning`.

However, in development environments, the log level is set to `Information`. This allows IDEs like Visual Studio Code to continue to launch the application in a browser, as it depends on the information logged to the console to know what URL to launch.

## Acquire Loggers via Dependency Injection

When you need a logger, simply inject one into your class.

```csharp
public class MyService
{
    private readonly ILogger<MyService> _logger;

    public MyService(ILogger<MyService> logger)
    {
        _logger = logger;
    }
}
```

## Log Monitoring Via AWS CloudWatch

In AWS Lambda functions, any output written to the console will automatically be captured and sent to Amazon CloudWatch Logs. AWS Lambda automatically creates a CloudWatch Logs group for your Lambda function (if one doesn’t already exist) and streams the console output to it.

To view the logs in CloudWatch:
- Open the AWS Management Console.
- Navigate to CloudWatch.
- In the left-hand menu, select Logs.
- Find the log group for your Lambda function (the name will typically follow the format /aws/lambda/<LambdaFunctionName>).
- Inside the log group, you’ll find log streams where each stream corresponds to a specific invocation of the Lambda.

This makes it straightforward to debug or monitor your Lambda functions using logs.