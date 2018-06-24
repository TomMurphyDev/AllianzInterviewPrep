using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace InsuranceApi.Models
{

    /*
     * This DTO is based on fields I commonly see in insurance question forms
     * for demonstration of manipulation via a web Api
     */
    public class UserItem
    {
        public long Id { get; set; }//generated on Insert
        [Required( ErrorMessage = "Name Is Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name Should be minimum 3 characters and a maximum of 100 characters")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Address Is Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name Should be minimum 3 characters and a maximum of 100 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Date Required DD/MM/YYYY")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public int NoClaimsYears { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public int YearsLicenceHeld  { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public bool Convictions { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public bool PenaltyPoints { get; set; }
        //For these methods I will write Unit Tests

        
        public double getAge() {
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - DateOfBirth.Year;
            // Go back to the year the person was born in case of a leap year
            if (DateOfBirth > today.AddYears(-age)) age--;
            return age;
        }
        /*
         *For this example we will assume that this hypothetical company 
         * prefers not to insure people with previous convictions.
         * So if they have a conviction we will not provide insurance
         * If they are under 17 they will not insure
         */
        public bool CanInsure() {
            if (getAge() >= 17 && Convictions == false)
            {
                return true;
            }
            else {
                return false;
            }
            
        }
        public double GetPremiumCost(UserItem i) {
            //Minimum Cost of Insurance
            if (CanInsure() == false) {
                throw new System.ArgumentException("U dont meet the citeria for insurance", "original");
            }
            double basePremium = 500;
            //figure that will be calculated based on information in fields
            double discountRatio =0.0;
            if (getAge() <23) {
                discountRatio += .20;
            }
            if (PenaltyPoints == true) {
                discountRatio += .2;
            }
            if (NoClaimsYears > 0) {
                for (int j = 0; j < NoClaimsYears; j++) {
                    discountRatio -= .015;
                }
            }
            double quote = basePremium + (basePremium * discountRatio);

            return quote;
        }
    }
}
