using System.ComponentModel.DataAnnotations;

namespace Template9.Dto;

/// <summary>
/// Represents a request dto.
/// </summary>
public class $(Sample)Request
{
    /// <summary>
    /// The name
    /// </summary>
    [Required]
    public required string Name { get; set; }
}
