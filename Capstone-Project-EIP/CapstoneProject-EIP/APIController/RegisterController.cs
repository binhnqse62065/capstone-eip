using CapstoneProject_EIP.Models;
using HmsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace CapstoneProject_EIP.APIController
{
    [RoutePrefix("api/landingPage")]

    public class RegisterController : ApiController
    {
        private HmsEntities db = new HmsEntities();
        [Route("AddGuest")]
        [HttpPost]
        public HttpResponseMessage AddGuest(Guest guest)
        {
            guest.TimeRegister = DateTime.Now;
            guest.IsCheckIn = false;
            db.Guests.Add(guest);
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Add successful!",
                })
            };
        }
    }
}
