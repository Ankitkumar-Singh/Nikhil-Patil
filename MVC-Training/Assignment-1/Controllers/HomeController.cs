using PartyInvites.Models;
using System;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        #region Display greetings
        /// <summary>Collects current time and greets.</summary>
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "GOOD MORNING" : "GOOD AFTERNOON";
            return View();
        }
        #endregion

        #region Get form data
        /// <summary>RSVPs the form.</summary>
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        #endregion

        #region Post form data
        /// <summary>RSVPs the form.</summary>
        /// <param name="guestResponce">The guest responce.</param>
        [HttpPost]
        public ViewResult RsvpForm(GuestResponce guestResponce)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponce);
            }
            else
            {
                return View();
            }
        }
        #endregion
    }
}