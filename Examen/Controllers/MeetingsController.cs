using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    public class MeetingsController : Controller
    {
        private Models.AppContext db = new Models.AppContext();
        private int perPage = 10;

        public ActionResult Index()
        {
            if (TempData.ContainsKey("message"))
                ViewBag.Message = TempData["message"];

            var meetings = db.Meetings.OrderByDescending(t => t.TitluMeet);
            var search = "";

            //cautare
            if (Request.Params.Get("search") != null)
            {
                search = Request.Params.Get("search").Trim();
                List<int> meetIds = db.Meetings.Where(t => t.TitluMeet.Contains(search)).Select(t => t.MeetId).ToList();
                meetings = db.Meetings.Where(t => meetIds.Contains(t.MeetId)).OrderByDescending(t => t.TitluMeet);
            }

            //paginare
            var totalMeetings = meetings.Count();
            var currentPage = Convert.ToInt32(Request.Params.Get("page"));
            var offset = 0;

            if (!currentPage.Equals(0))
            {
                offset = (currentPage - 1) * perPage;
            }

            var paginatedMeetings = meetings.Skip(offset).Take(perPage);

            ViewBag.perPage = perPage;
            ViewBag.total = totalMeetings;
            ViewBag.lastPage = Math.Ceiling((float)totalMeetings / (float)perPage);
            ViewBag.Meetings = paginatedMeetings;
            return View();
        }

    }
}