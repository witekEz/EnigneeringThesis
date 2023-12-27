﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Services.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        private readonly Stopwatch _stopwatch;
        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
            _stopwatch=new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            
             _stopwatch.Start();
             await next.Invoke(context);
             _stopwatch.Stop();
             var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;
             if (elapsedMilliseconds/1000 > 4)
             {
                 var message = $"Request [{context.Request.Method}] at {context.Request.Path} took {elapsedMilliseconds} ms";
                 _logger.LogInformation(message);
             }
        }
    }
}
