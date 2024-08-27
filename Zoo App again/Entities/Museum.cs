using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_App_again.Entities
{
    public class Museum
    {
        public int Id { get; set; }
        public string? Name { get; set; }    
        public DateTime HistoryOfConstruction { get; set; }
        public string? Founder {  get; set; }    
        public string ? HistoricalInformation {  get; set; }  
    }
}
