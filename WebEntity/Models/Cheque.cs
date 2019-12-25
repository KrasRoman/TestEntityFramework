using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebEntity.Models
{
    public class Cheque
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Position> Positions { get; set; } = new List<Position>();

        public Cheque()
        {
            Date = DateTime.Now;
            for (int i = 0;i<10;i++)
            Positions.Add(new Position());
        }
       
    }

    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Position()
        {
            Name = "New position";
            Price = 10;
        }
    }
}
