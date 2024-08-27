using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_App_again.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string? Classification {  get; set; }    
        public string? Type { get; set; }
        public int Quantity { get; set; }
        public double PricePerOne { get; set; }
        public string? Description { get; set; }

        //relation one from animal
        public int? animalPlaceId { get; set; }
        public AnimalPlace? AnimalPlace { get; set; }


        //relation one from animal to imports

        public int? importsId { get; set; }
        public Imports? imports { get; set; }

    }
}
