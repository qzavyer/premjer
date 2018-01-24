using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.DataBase
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int FilmId { get; set; }
        public int Count { get; set; }

        [ForeignKey("FilmId")]
        public Film Film { get; set; }
    }
}
