using System.Collections.Generic;
using Server.DataBase;

namespace Server.Interfaces
{
    public interface IDbContext
    {
        IEnumerable<Film> GetAcualFilms();
        Film GetFilm(int filmId);
        IEnumerable<Hall> GetHalls();
        void SaveFilm(Film film);
        void SaveTiket(Ticket ticket);
        void DeleteFilm(int filmId);
    }
}
