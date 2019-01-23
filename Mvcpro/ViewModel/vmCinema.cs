using Mvcpro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvcpro.ViewModel
{
    public class vmCinema
    {
        public IEnumerable<show> Shows { get; set; }
        public IEnumerable<cinema> Cinemas { get; set; }

        public IEnumerable<movy> Movies { get; set; }

        public show showinfo { get; set; }

        public IEnumerable<String> seatno { get; set; }

        public int totalprice {get; set; }

        public IEnumerable<Ticket> ticketinfo { get; set; }

    }
}