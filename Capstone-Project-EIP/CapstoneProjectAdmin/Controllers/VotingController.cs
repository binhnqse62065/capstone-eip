using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    public class VotingController : Controller
    {
        // GET: Voting
        public ActionResult Index(int id)
        {
            ViewBag.EventId = id;
            return View();
        }
    }
}