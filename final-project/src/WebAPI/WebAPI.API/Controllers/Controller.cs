using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.API.Controllers;
public abstract class Controller : ControllerBase {
    private ISender? sender;

    protected ISender Sender => sender ??= this.HttpContext.RequestServices.GetRequiredService<ISender>();
}