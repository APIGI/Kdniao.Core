﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Aspnetcore.Controllers
{
    /// <summary>
    /// 快递鸟异步通知
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("快递鸟异步通知")]
    public class KdniaoNotifyController : ControllerBase
    {

    }
}