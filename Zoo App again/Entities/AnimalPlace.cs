using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_App_again.Entities
{
    public class AnimalPlace
    {
        public int Id {  get; set; }    
        public string?   Name { get; set; }
        public List<Animal>? Existing_Animals { get; set; }
    }
}
