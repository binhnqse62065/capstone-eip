using CapstoneProjectClient.Models;
using HmsService.Sdk;
using HmsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProjectClient.API
{
    [RoutePrefix("api/login")]
    public class LoginAPIController : ApiController
    {
        [Route("CheckCodeLogin/{code}")]
        [HttpPost]
        public HttpResponseMessage CheckCodeLogin(string code)
        {
            try
            {
                EventApi eventApi = new EventApi();
                int codeLogin = Int32.Parse(code);
                var eventCheck = eventApi.CheckLoginCode(codeLogin);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true,
                        eventId = eventCheck != null ?  eventCheck.EventID : 0,
                        data = eventCheck.Sessions.Select(s => new SessionViewModel {
                            Name = s.Name,
                            SessionID = s.SessionID,
                            EventId = s.EventId
                        })
                    })
                };
            }
            catch(Exception e)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new JsonContent(new
                    {
                        success = false  
                    })
                };
            }
        }
    }
}
