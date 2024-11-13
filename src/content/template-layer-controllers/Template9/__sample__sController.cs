using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template9.Dto;
using Microsoft.Extensions.Logging;

namespace Template9;

/// <summary>
/// A $(Sample)s controller with basic CRUD operations.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class $(Sample)sController : ControllerBase
{
    private readonly ILogger<$(Sample)sController> _logger;

    public $(Sample)sController(ILogger<$(Sample)sController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets a list of objects.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<$(Sample)Response>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<$(Sample)Response>>> Get(CancellationToken token)
    {
        return Ok(new[]
        {
            new $(Sample)Response { Id = 1, Name = "value1" },
            new $(Sample)Response { Id = 2, Name = "value2" }
        });
    }

    /// <summary>
    /// Gets a object by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof($(Sample)Response), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Get(int id, CancellationToken token)
    {
        return Ok(new $(Sample)Response { Id = id, Name = "value" + id });
    }

    /// <summary>
    /// Creates a new object.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof($(Sample)Response), StatusCodes.Status201Created)]
    public async Task<ActionResult<$(Sample)Response>> Post($(Sample)Request request, CancellationToken token)
    {
        var response = new $(Sample)Response
        {
            Id = Random.Shared.Next(1,100),
            Name = request.Name
        };

        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    /// <summary>
    /// Updates a object by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof($(Sample)Response), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<$(Sample)Response>> Put(int id, $(Sample)Request request, CancellationToken token)
    {
        return Ok(new $(Sample)Response { Id = id, Name = request.Name });
    }

    /// <summary>
    /// Deletes a object by its unique identifier.
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
