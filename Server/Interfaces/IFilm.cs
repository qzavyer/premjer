using System;

namespace Server.Interfaces
{
    public interface IFilm
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime Time { get; set; }
        decimal Price { get; set; }
        int FreeCount { get; }
    }
}