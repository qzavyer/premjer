using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Server.DataBase;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers
{
    [Produces("application/json")]
    [Route("api/ticket")]
    public class TicketController : Controller
    {
        private readonly IDbContext _dbContext;


        public TicketController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<IFilm> Get()
        {
            return _dbContext.GetAcualFilms().Select(r=>new FilmViewModel(r));
        }

        [HttpPost]
        public string Post([FromBody]Ticket ticket)
        {
            try
            {
                _dbContext.SaveTiket(ticket);
                return "Покупка завершена";
            }
            catch (Exception exception)
            {
                Response.StatusCode = 500;
                return exception.Message;
            }
        }
    }
}
