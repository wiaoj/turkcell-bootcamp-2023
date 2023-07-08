using Application.Application.Features.Surveys.Commands.CreateSurvey;
using Application.Application.Features.Surveys.Queries.GetAllSurvey;
using Application.Application.Features.Surveys.Queries.GetSurvey;
using Application.DataTransferObjects.Requests.Surveys;
using Application.DataTransferObjects.Responses.Surveys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SurveysController : Controller {
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(
        CreateSurveyRequest request,
        CancellationToken cancellationToken) {
        string surveyId = await this.Sender.Send(new CreateSurveyCommand(request), cancellationToken);
        return CreatedAtAction(nameof(GetBySurveyId), new { id = surveyId }, null);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken) {
        IEnumerable<SurveyDisplayResponse> response =
            await this.Sender.Send(new GetAllSurveyQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetBySurveyId(string id, CancellationToken cancellationToken) {
        SurveyDisplayResponse response =
            await this.Sender.Send(new GetSurveyQuery(id), cancellationToken);
        return Ok(response);
    }
}