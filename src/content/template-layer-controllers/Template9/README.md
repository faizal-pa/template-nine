# Template9

Include the package controllers in a WebApi project by referencing the method in the `CompositionExtensions` class when adding controllers to the application.

```csharp
builder.Services.AddControllers()
    .AddSampleControllers();
```

<!-- Optional: Describe the purpose of the controllers in this package. -->