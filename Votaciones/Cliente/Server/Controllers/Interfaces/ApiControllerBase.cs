﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Server.Controllers.Interfaces;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender mediator = null!;

    protected ISender Mediator => this.mediator ??= HttpContext.RequestServices.GetService<ISender>() ?? null!;
}