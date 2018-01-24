using System;
using Server.Interfaces;

namespace Server.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class FilmViewModel : IFilm
    {
        public FilmViewModel(IFilm film)
        {
            Id = film.Id;
            Name = film.Name;
            Time = film.Time;
            Price = film.Price;
            FreeCount = film.FreeCount;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
        public int FreeCount { get; }
    }
}