using Application.Application.Features.Users.Commands.Register;
using Application.Application.Features.Users.Queries.Login;
using Application.DataTransferObjects.Requests.Authentication;
using Application.DataTransferObjects.Responses.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : Controller {

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken) {
        AuthenticationResponse registerCommandResponse = await this.Sender.Send(new RegisterCommand(request), cancellationToken);
        return this.Created("", registerCommandResponse);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken) {
        AuthenticationResponse loginQueryResponse = await this.Sender.Send(new LoginQuery(request), cancellationToken);
        return this.Ok(loginQueryResponse);
    }
}