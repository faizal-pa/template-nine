# Template9.Common.Mapper

Provides abstractions and extensions for working with AutoMapper.

## AutoMapper Abstractions

| Abstraction               | Description                                           |
|---------------------------|-------------------------------------------------------|
| IAutoMapperConfiguration  | Interface to provide a mapper configuration           |
| DomainMapperConfiguration | Base class that implements `IAutoMapperConfiguration` |

> The constructor for `DomainMapperConfiguration` will call the `ConfigureMapper` method, and validate the configuration.

### Sample Implementation

```csharp
public class ProjectMapperConfiguration : DomainMapperConfiguration
{
    protected override MapperConfiguration ConfigureMapper()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<SomeMapperProfile>();
        });
    }
}
```

Inject the mapper configuration as a singleton to make it available to your services.

```csharp
public IServiceCollection ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IAutoMapperConfiguration, ProjectMapperConfiguration>();
}
```

## Extension Methods

Extension methods are provided to ease the creation of map profiles and transform objects.

### Map Profile Extensions

All methods below are extension on `IMappingExpression<TSource, TDestination>`, which is the object returned from `CreateProfile<TSource, TDestination>`.

| Method | Description                                                                                                   |
|--------|---------------------------------------------------------------------------------------------------------------|
| AndMap | Alias for AutoMapper method `ForMember` where the source member is defined first, then the destination member |
| Ignore | Alias for AutoMapper method `ForMember` where the mapping expression is set to ignore                         |

### Object Extensions

All object extensions take an instance of `IAutoMapperConfiguration` as a required first parameter.

| Method                       | Object                    | Description                                                                       |
|------------------------------|---------------------------|-----------------------------------------------------------------------------------|
| MapTo&lt;TDestination&gt;    | object                    | Maps the object to an object of type TDestination                                 |
| MapTo&lt;T, TDestination&gt; | IEnumerable&lt;T&gt;      | Maps an enumeration of instances of type T to an enumeration of type TDestination |
| MapTo&lt;TDestination&gt;    | IEnumerable&lt;object&gt; | Maps an enumeration of instances to an enumeration of type TDestination           |
