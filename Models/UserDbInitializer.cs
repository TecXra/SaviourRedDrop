
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace SaviourRedDrop.Models
{
    public class UserDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<UserDbContext>
    {
       
        
  protected override void Seed(UserDbContext context)
   {

            var city = new List<City>
              {
               new City { CityName="Badamibag" },
               new City { CityName="Cooperative Store" },
               new City {CityName="Dharampura" },
               new City { CityName="Darogawala" },
               new City { CityName="Faisal Town" },
               new City { CityName="Gari Shau" },
               new City { CityName="Ghazi Road" },
               new City { CityName="Gajumata" },
               new City { CityName="Ichra" },
               new City { CityName="Johar Town" },
               new City {CityName="Lahore Cantt" },
               new City {CityName="Manavaa" },
               new City {CityName="Mazang" },
               new City { CityName="Muslim Town" },
               new City {CityName="Mall Road" },
               new City { CityName="Model Town" },
               new City {CityName="Shadhra" },
               new City { CityName="Sabzazar" },
               new City {CityName="Shalamar Bag" },
               new City {CityName="Thokar Naiz Baig" },
               new City { CityName="Town Ship" },
               new City { CityName="Wahdat Road" },
                              
              };
            city.ForEach(d => context.dbCity.Add(d));


            context.SaveChanges();


            var bloodGroup = new List<BloodGroup>
       {

          new BloodGroup {BloodGroupName="A+" },
          new BloodGroup { BloodGroupName="B+" },
          new BloodGroup { BloodGroupName="AB+" },
          new BloodGroup { BloodGroupName="O+" },
          new BloodGroup { BloodGroupName="A-" },
          new BloodGroup { BloodGroupName="B-" },
          new BloodGroup { BloodGroupName="AB-" },
          new BloodGroup { BloodGroupName="O-" }
    };
            bloodGroup.ForEach(d => context.dbBloodGroup.Add(d));

            context.SaveChanges();


            /****************************************************/
            var abcd = new List<SaviourRDUser>
               {
                new SaviourRDUser {UserName="Ali",Name="Raza", Password = "1122", BGId = 1, Area = 1, PhoneNumber = "0324" },
                new SaviourRDUser { UserName = " Raza",Name="Ali",Password = "1", BGId = 2, Area = 2, PhoneNumber = "0324" }
            };
          abcd.ForEach(d => context.dbUser.Add(d));
                     
                context.SaveChanges();


            var review = new List<Review>
              {
                //new Review { UserId=2,FeedBack="Enter your view", writerId=1 },
                //new Review {UserId=1,FeedBack="Hello",writerId=1 },
                // new Review {UserId=1,FeedBack="dhfdjfdffj",writerId=1 },
                //  new Review {UserId=1,FeedBack=" i love you  ",writerId=1 },
                //   new Review {UserId=1,FeedBack="SSSSSSSSSS",writerId=1 },

              };
            review.ForEach(d=> context.dbReview.Add(d));
            context.SaveChanges();
            base.Seed(context);
}
    }
}
