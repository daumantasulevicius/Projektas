using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektas
{
    public class KrepselioPreke
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int quantity { get; set; }
        public string href { get; set; }

        public KrepselioPreke(int Id, string Label, string Type, double Price, int quantity, string href)
        {
            this.Id = Id;
            this.Label = Label;
            this.Type = Type;
            this.Price = Price;
            this.quantity = quantity;
            this.href = href;
        }
    }
}
