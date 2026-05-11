using Microsoft.AspNetCore.Mvc;
using Wunderbar.Application.Interfaces;

namespace Wunderbar.Presentation.Controllers;

public class AutoCompleteController : ControllerBase
{
    private readonly IAutoCompleteService _autoCompleteService;

    public AutoCompleteController(IAutoCompleteService autoCompleteService)
    {
        _autoCompleteService = autoCompleteService;
    }

    [HttpGet("api/[controller]")]
    public IActionResult GetTopSuggestions(string query)
    {
        var suggestions = _autoCompleteService.GetTopSuggestions(query);

        if (query is null)
        {
            return BadRequest(suggestions);
        }

        return Ok(suggestions);
    }
}