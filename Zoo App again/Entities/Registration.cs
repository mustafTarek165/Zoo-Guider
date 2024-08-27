using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_App_again.Entities
{
    public class Registration
    {
        public int Id { get; set; }
        public string ?UserName {get; set;}
        public string ?Password { get; set;}
    }
}
