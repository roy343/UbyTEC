using FeedbackAPI.Models;
using FeedbackAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api")]
public class FeedbackController : ControllerBase
{
    private readonly FeedbackService _feedbackService;

    public FeedbackController(FeedbackService feedbackService) =>
        _feedbackService = feedbackService;

    [HttpGet]
    public async Task<List<Feed>> Get() =>
        await _feedbackService.GetAsync();

    [HttpGet("test/{a}")]
    public IActionResult Get(int a){ return Ok("Hello World!" + a); }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Feed>> Get(string id)
    {
        var feed = await _feedbackService.GetAsync(id);

        if (feed is null)
        {
            return NotFound();
        }

        return feed;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Feed newEntry)
    {
        await _feedbackService.CreateAsync(newEntry);

        return CreatedAtAction(nameof(Get), new { id = newEntry.Id }, newEntry);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var feed = await _feedbackService.GetAsync(id);

        if (feed is null)
        {
            return NotFound();
        }

        await _feedbackService.RemoveAsync(id);

        return NoContent();
    }
}