using Application.Application.Features.Answers.Commands.AnswerSurvey;
using Application.Application.Features.Answers.Queries.GetAllAnswer;
using Application.Application.Features.Answers.Queries.GetAnswer;
using Application.DataTransferObjects.Requests.Answers;
using Application.DataTransferObjects.Responses.Answers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnswersController : Controller {
    [HttpPost]
    public async Task<IActionResult> Answer(
        AnswerSurveyRequest request,
        CancellationToken cancellationToken) {
        await this.Sender.Send(new AnswerSurveyCommand(request), cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken) {
        IEnumerable<AnswerDisplayResponse> response = 
            await this.Sender.Send(new GetAllAnswerQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetByAnswerId(string id, CancellationToken cancellationToken) {
        AnswerDisplayResponse response = 
            await this.Sender.Send(new GetAnswerQuery(id), cancellationToken);
        return Ok(response);
    }
    
    [HttpGet]
    [Route("{id}/statistics")]
    [Authorize]
    public async Task<IActionResult> GetStatisticsByAnswerId(string id, CancellationToken cancellationToken) {
        AnswerStatisticsResponse response = 
            await this.Sender.Send(new GetAnswerStatisticsQuery(id), cancellationToken);
        return Ok(response);
    }
}