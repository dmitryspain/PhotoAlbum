using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace PhotoAlbum.WebApi.Filters
{
    //public class GlobalExceptionFilter : ExceptionFilterAttribute
    //{
    //    public string Message { get; set; }
    //    public Type ExceptionType { get; set; }
    //    public HttpStatusCode StatusCode { get; set; }

    //    public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
    //    {
    //        if (actionExecutedContext.Exception.GetType() == typeof())
    //        {
    //            StatusCode = actionExecutedContext.Response.StatusCode;
    //            Message = actionExecutedContext.Response.RequestMessage.ToString();
    //            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(StatusCode, Message);
    //        }
    //        return Task.FromResult<object>(null);
    //    }
    //}

    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            if (context.Exception is ArgumentNullException)
            {
                result = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "ArgumentNullException"
                };

            }
            else if(context.Exception is NullReferenceException)
            {
                result = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "NullReferenceException"
                };
            }

            context.Result = new HttpResult(context.Request, result);
        }

        public class HttpResult : IHttpActionResult
        {
            private HttpRequestMessage _request;
            private HttpResponseMessage _httpResponseMessage;


            public HttpResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
            {
                _request = request;
                _httpResponseMessage = httpResponseMessage;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(_httpResponseMessage);
            }
        }
    }
}