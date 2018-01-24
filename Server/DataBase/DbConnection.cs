using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Server.Interfaces;

namespace Server.DataBase
{
    public class DbConnection : DbContext, IDbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options): base(options)
        {
            ConnectionString = options.GetExtension<SqlServerOptionsExtension>().ConnectionString;
        }

        private DbSet<Film> Films { get; set; }
        private DbSet<Hall> Halls { get; set; }
        private DbSet<Ticket> Tickets { get; set; }
        private string ConnectionString { get; }

        public IEnumerable<Film> GetAcualFilms()
        {
            return Films.Include(f=>f.Hall).Include(f=>f.Tickets).Where(f => f.Time >= DateTime.Now);
        }

        public Film GetFilm(int filmId)
        {
            return Films.Include(f => f.Hall).Include(f => f.Tickets).FirstOrDefault(f => f.Id == filmId);
        }

        public IEnumerable<Hall> GetHalls()
        {
            return Halls;
        }

        public void SaveFilm(Film film)
        {
            if (film.Id > 0)
            {
                Update(film);
            }
            else
            {
                Add(film);
            }
            SaveChanges();
        }

        public void SaveTiket(Ticket ticket)
        {
            var film = GetFilm(ticket.FilmId);
            if(film.FreeCount<ticket.Count)throw new Exception("Недопустимое количество");
            Add(ticket);
            SaveChanges();
        }

        public void DeleteFilm(int filmId)
        {
            var film = GetFilm(filmId);
            Remove(film);
            SaveChanges();
        }
    }
}