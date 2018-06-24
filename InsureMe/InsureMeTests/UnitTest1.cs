using System;
using Xunit;
using InsureMe.Models;
namespace InsureMeTests
{
    public class UnitTest1
    {
        [Fact]
        public void GetAgeLogicTest()
        {
            //arrange
            User user = new User();
            user.FullName = "Bob Worth";
            user.Address = "4 candy land way";
            user.DateOfBirth = DateTime.Now;//this should be today
            //act
            double age = user.getAge();
            //assert
            Assert.Equal(0, age + 1);//adjusted for simplicity understanding datetimenow output
        }

        [Fact]
        public void CanInsureAgeLogicTest()
        {
            //arrange
            User user = new User();
            user.FullName = "Bob Worth";
            user.Address = "4 candy land way";
            user.DateOfBirth = DateTime.Now;//this should be today
            user.Convictions = false;
            //act
            //User does not meet conditions as they are (-1 years old by calculation)
            //Though they have no convictions
            //Must fufill Both assumptions
            bool status = user.CanInsure();
            //assert
            Assert.False(status);
        }

        [Fact]
        public void CanInsureConvictionLogicTest()
        {
            //arrange
            User user = new User();
            user.FullName = "Bob Worth";
            user.Address = "4 candy land way";
            DateTime value = new DateTime(1985, 1, 18);
            user.DateOfBirth =value ;//this should be >17
            user.Convictions = true;//
            //act
            //User does not meet conditions as they are (-1 years old by calculation)
            //Though they have no convictions
            //Must fufill Both assumptions
            bool status = user.CanInsure();
            //assert
            Assert.False(status);
        }
        /*Not Applicable as default value is false for bool value
         * [Fact]
        public void CanInsureConvictionNullTest()
        {
            //arrange
            User user = new User();
            user.FullName = "Bob Worth";
            user.Address = "4 candy land way";
            DateTime value = new DateTime(1985, 1, 18);
            //act
            //User does not meet conditions as they are (-1 years old by calculation)
            //Must not me null
            bool status = user.CanInsure();
            //assert
            Assert.False(status);
        }
         */
        [Fact]
        public void GetPremiumCostTest()
        {
            //arrange
            User user = new User();
            user.FullName = "Bob Worth";
            user.Address = "4 candy land way";
            user.DateOfBirth = DateTime.Now;//this should be today
            user.Convictions = true;//
            //act
            Action act = () => user.GetPremiumCost(user);
            //assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}
