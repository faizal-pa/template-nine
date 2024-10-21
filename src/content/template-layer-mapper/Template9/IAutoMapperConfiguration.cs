using AutoMapper;

namespace Template9;

public interface IAutoMapperConfiguration
{
    /// <summary>
    /// Get the IMapper instance to use for performing mapping operations.
    /// </summary>
    IMapper Mapper { get; }
}
