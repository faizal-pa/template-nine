using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template9.Dto;
using Microsoft.Extensions.Logging;

namespace Template9;

/// <summary>
/// A $(PartialName)s controller with basic CRUD operations.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class $(PartialName)sController : ControllerBase
{
    private readonly ILogger<$(PartialName)sController> _logger;

    public $(PartialName)sController(ILogger<$(PartialName)sController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets a list of objects.
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<$(PartialName)Response>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<$(PartialName)Response>>> Get(CancellationToken token)
    {
        return await Task.FromResult
        (
            Ok(new[]
            {
                new $(PartialName)Response { Id = 1, Name = "value1" },
                new $(PartialName)Response { Id = 2, Name = "value2" }
            }
        ));
    }

    /// <summary>
    /// Gets a object by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof($(PartialName)Response), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Get(int id, CancellationToken token)
    {
        return await Task.FromResult
        (
            Ok(new $(PartialName)Response { Id = id, Name = "value" + id })
        );
    }

    /// <summary>
    /// Creates a new object.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof($(PartialName)Response), StatusCodes.Status201Created)]
    public async Task<ActionResult<$(PartialName)Response>> Post($(PartialName)Request request, CancellationToken token)
    {
        var response = new $(PartialName)Response
        {
            Id = Random.Shared.Next(1,100),
            Name = request.Name
        };

        return await Task.FromResult(CreatedAtAction(nameof(Get), new { id = response.Id }, response));
    }

    /// <summary>
    /// Updates a object by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof($(PartialName)Response), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<$(PartialName)Response>> Put(int id, $(PartialName)Request request, CancellationToken token)
    {
        return await Task.FromResult(Ok(new $(PartialName)Response { Id = id, Name = request.Name }));
    }

    /// <summary>
    /// Deletes a object by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await Task.CompletedTask;
        return NoContent();
    }
}
