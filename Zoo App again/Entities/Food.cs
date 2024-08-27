using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_App_again.Entities
{
    public class Food
    {
        public int Id { get; set; } 
        public int Quantity { get; set; }   
        public string ?Type {  get; set; }
        public double PricePerKilo { get; set; }  
        public string ?Description { get; set; }

        //relation one from food to imports

        public int importsId { get; set; }
        public Imports imports { get; set; } = null!;

    }
}
