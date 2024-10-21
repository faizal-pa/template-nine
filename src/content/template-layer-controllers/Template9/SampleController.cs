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
    /// <summary>
    /// Gets a list of samples.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SampleResponse>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<SampleResponse>> Get()
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
    public ActionResult<string> Get(int id)
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
    public ActionResult<SampleResponse> Post(SampleRequest request)
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
    public ActionResult<SampleResponse> Put(int id, SampleRequest request)
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
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
