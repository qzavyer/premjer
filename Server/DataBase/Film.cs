using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Server.Interfaces;

namespace Server.DataBase
{
    public class Film : IFilm
    {
        public Film()
        {
            Time = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }
        [Required]
        public int HallId { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("HallId")]
        public Hall Hall { get; set; }
        public List<Ticket> Tickets { get; set; }

        private int HallCapacity => Hall?.Capacity ?? 0;
        private int TicketCount => Tickets?.Sum(t=>t.Count) ?? 0;
        public int FreeCount => HallCapacity - TicketCount;
    }
}