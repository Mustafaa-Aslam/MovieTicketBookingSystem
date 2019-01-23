using Mvcpro.Models;
using Mvcpro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcpro.Controllers
{
    public class HomeController : Controller
    {
        cinema_appContext db = new cinema_appContext();
      
        // GET: Home
        public ActionResult Index(DateTime? date)
        {
           

        // GET: Home
            vmCinema vmCi = new vmCinema();

            if (date != null)
            {
                vmCi.Shows = db.shows.Where(s => s.show_date == date).ToList();
                vmCi.Cinemas = db.cinemas.ToList();
                vmCi.Movies = db.movies.ToList();
                ViewBag.date = date;    
            }



            return View(vmCi);
        }

        public ActionResult bktickets(int? id)
        {
            vmCinema vmCi = new vmCinema();
            vmCi.showinfo = db.shows.Where(s => s.show_id == id).Single();
            vmCi.ticketinfo = db.Tickets.Where(t => t.show_id == id).ToList();
            
           
            return View(vmCi);
        }


        [HttpPost,ActionName("bktickets")]
        public ActionResult submit1(int? showid, String[] seatno1) {
            vmCinema vmCi = new vmCinema();

            
            if (seatno1 != null && showid!=0)
            {
                vmCi.showinfo = db.shows.Where(s => s.show_id == showid).Single();
                int count = db.Tickets.Count();
                count++;
                for (int i = 0; i < seatno1.Length; i++)
                {
                    if (ModelState.IsValid)
                    {
                        db.Tickets.Add(new Ticket
                        {
                            ticket_id= count,
                            show_id = (int)showid,
                            ticket_price = 700,
                            seatno = seatno1[i]
                        });
                        db.SaveChanges();
                        count++;
                    }
                }
                
            }
            
            return RedirectToAction("bktickets",new {id=showid} );

        }
    }
}