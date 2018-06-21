using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Models
{

    /*
     * This DTO is based on fields I commonly see in insurance question forms
     * for demonstration of manipulation via a web Api
     */
    public class UserItem
    {
        public long Id { get; set; }//generated on Insert
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NoClaimsYears { get; set; }
        public int YearsLicenceHeld  { get; set; }
        public bool Convivtions { get; set; }
        public bool PenaltyPoints { get; set; }
    }
}
