using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AttendenceManagementAPI.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GlobalExceptionFilter));

        public void OnException(ExceptionContext context)
        {
            log.Error("Unhandled exception occurred", context.Exception);

            context.Result = new ObjectResult(new
            {
                Message = "Something went wrong.",
                Details = context.Exception.Message
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
