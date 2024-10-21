using AutoMapper;

namespace Template9.Common.Mapper;

/// <summary>
/// Interface to provide a mapper configuration
/// </summary>
public interface IAutoMapperConfiguration
{
    /// <summary>
    /// The IMapper instance to use for performing mapping operations.
    /// </summary>
    IMapper Mapper { get; }
}
