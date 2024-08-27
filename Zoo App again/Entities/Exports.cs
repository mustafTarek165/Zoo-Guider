using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_App_again.Entities
{
    public class Exports
    {
        public int Id {  get; set; }    
        public string? OrganizationExportedTo { get; set; }    
        public string? Country { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }   
        public DateTime HistoryOfProcess { get; set; }

    }
}
