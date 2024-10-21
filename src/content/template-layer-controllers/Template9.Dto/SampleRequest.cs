using System.ComponentModel.DataAnnotations;

namespace Template9.Dto;

/// <summary>
/// Represents a sample request.
/// </summary>
public class SampleRequest
{
    /// <summary>
    /// The name of the sample.
    /// </summary>
    [Required]
    public required string Name { get; set; }
}
