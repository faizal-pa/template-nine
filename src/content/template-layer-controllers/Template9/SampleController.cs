using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template9.Dto;

namespace Template9;

/// <summary>
/// Represents a sample controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SampleController : ControllerBase
{
    private readonly ILogger<SampleController> _logger;

    public SampleController(ILogger<SampleController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets a list of samples.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SampleResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SampleResponse>>> Get(CancellationToken token)
    {
        return Ok(new[]
        {
            new SampleResponse { Id = 1, Name = "value1" },
            new SampleResponse { Id = 2, Name = "value2" }
        });
    }

    /// <summary>
    /// Gets a sample by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SampleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Get(int id, CancellationToken token)
    {
        return Ok(new SampleResponse { Id = id, Name = "value" + id });
    }

    /// <summary>
    /// Creates a new sample.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(SampleResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<SampleResponse>> Post(SampleRequest request, CancellationToken token)
    {
        var response = new SampleResponse
        {
            Id = Random.Shared.Next(1,100),
            Name = request.Name
        };

        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    /// <summary>
    /// Updates a sample by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(SampleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SampleResponse>> Put(int id, SampleRequest request, CancellationToken token)
    {
        return Ok(new SampleResponse { Id = id, Name = request.Name });
    }

    /// <summary>
    /// Deletes a sample by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        return NoContent();
    }
}
