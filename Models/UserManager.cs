using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SaviourRedDrop.Models
{
    public class UserManager : IUserManager
    {
        private int _nextId = 1;
        List<SaviourRDUser> Users = new List<SaviourRDUser>();
        private UserDbContext db =   new UserDbContext();

        public UserManager()
        {


       //        Add(new SaviourRDUser {UserName = "Ali", Password="1122",BloodGroup="o+",Area ="Lahore", PhoneNumber = "0324" });

      //      Add(new SaviourRDUser { UserName = "Hafiz Raza", Password = "112", BloodGroup = "o+", Area = "Lahore", PhoneNumber = "0324" });

    //        Add(new SaviourRDUser { UserName = "Mannan", Password = "12", BloodGroup = "Ab+", Area = "Lahore", PhoneNumber = "033" });

            }

        public IEnumerable<SaviourRDUser> GetAll()
        {
            var userMan = db.dbUser.Include(p => p.Reviews).ToList<SaviourRDUser>();
            return userMan;
        }
        public SaviourRDUser Get(int id)
        {
           var user = db.dbUser.Find(id);
          var user1 = user;
          //  var user = Users.FirstOrDefault(  (p) => p.Id == id   );
            return user;
        }
        public SaviourRDUser Add(SaviourRDUser item)
        {
             item.Id = _nextId++;
            item = db.dbUser.Add(item);
               db.SaveChanges();
               Users.Add(item);

            return item;
        }
        public bool Update(SaviourRDUser item)
        {
            if (item == null)
                return false;
          //  int index = Users.FindIndex((p) => p.Id == item.Id);
           // var prod = db.dbUser.Find(item.Id);
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            /*
                if (index == -1)
                     return false;
                 Users.RemoveAt(index);
                 Users.Add(item);
                
            var product = db.dbUser.Find(item.Id);
                        //product.Price = item.Price;



                        db.Entry(product).State = EntityState.Modified;
                        
            
                db.dbUser.Attach(item);
                var entry = db.Entry(item);
                db.Entry(entry).State = EntityState.Modified;
              */  
            /*var local = db.Set<Product>()
                                         .Local
                                         .FirstOrDefault(f => f.Id == item.Id);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();

    */

            return true;
        }
        public SaviourRDUser Search(SaviourRDUser Id)
        {
            var user = db.dbUser.Find(Id);
           
            return user;
        }  

        public void Delete(int Id)
        {
            var delete = db.dbUser.Find(Id);
            db.dbUser.Remove(delete);

        }
    }
}