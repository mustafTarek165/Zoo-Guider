using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_App_again.Entities
{
    public class Imports
    {
        public int Id { get; set; }
        public string? Classification { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public DateTime HistoryOfProcess {  get; set; } 
        public string? OrganizationImportedFrom {  get; set; } 
        public string? Country {  get; set; }
        public double TotalPrice { get; set; }


        public Animal? Existing_Animals { get; set; }
        public Food? Foods { get; set; }
    }
}
