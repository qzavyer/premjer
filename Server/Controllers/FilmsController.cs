using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Server.DataBase;
using Server.Interfaces;

namespace Server.Controllers
{
    [Route("films")]
    public class FilmsController : Controller
    {
        private readonly IDbContext _dbContext;
        public FilmsController(IDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("table")]
        public IActionResult FilmTable()
        {
            var films = _dbContext.GetAcualFilms();
            return PartialView(films);
        }

        [HttpGet("{filmId:int}/edit")]
        public IActionResult EditFilm(int filmId)
        {
            var film = _dbContext.GetFilm(filmId) ?? new Film();
            ViewBag.Halls = _dbContext.GetHalls().OrderBy(h => h.Number).Select(h =>
                new SelectListItem
                {
                    Selected = h.Id == film.HallId,
                    Text = h.Number,
                    Value = h.Id.ToString()
                });
            return PartialView(film);
        }

        [HttpPost("save")]
        public IActionResult SaveFilm(Film film)
        {
            _dbContext.SaveFilm(film);
            return Json(true);
        }

        [HttpGet("{filmId:int}/delete")]
        public IActionResult DeleteFilm(int filmId)
        {
            _dbContext.DeleteFilm(filmId);
            return Json(true);
        }
    }
}
