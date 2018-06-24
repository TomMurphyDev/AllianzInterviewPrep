using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsureMe.Models
{
    public class User
    {
        public long ID { get; set; }//generated on Insert
        [Required(ErrorMessage = "Name Is Required")]
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
        public int YearsLicenceHeld { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public bool Convictions { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public bool PenaltyPoints { get; set; }

        //Class Logic
        public double getAge()
        {
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
        public bool CanInsure()
        {
           
            if (getAge() >= 17 && Convictions == false)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //there is no reason for this function to take its calling object as an input
        //as all vars are publicly available
        public double GetPremiumCost(User i)
        {
            //Minimum Cost of Insurance
            if (CanInsure() == false)
            {
                throw new System.ArgumentException("U dont meet the citeria for insurance", "original");
            }
            double basePremium = 500;
            //figure that will be calculated based on information in fields
            double discountRatio = 0.0;

            if (getAge() > 23)
            {
                //20% discount
                discountRatio += .20;
            }
            else {
                basePremium = basePremium * 1.2;
            }
            if (PenaltyPoints == false)
            {
                //20% discount
                //i.e if you have both above ur discount = 40%
                discountRatio += .2;
            }
            else {
                basePremium = basePremium * 1.2;
            }
            if (NoClaimsYears > 0)
            {
                //for every year no claims get a 1.5% extra discount
                for (int j = 0; j < NoClaimsYears; j++)
                {
                    discountRatio += .015;
                }
            }
            //
            double quote = basePremium * (1 - discountRatio);
            if (quote < 500)
            {
                return basePremium;
            }
            else {
                return quote;
            }
        }
    }
}
