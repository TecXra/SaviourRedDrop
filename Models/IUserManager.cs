using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaviourRedDrop.Models
{
    interface IUserManager
    {
        SaviourRDUser Add(SaviourRDUser item);
        SaviourRDUser Search(SaviourRDUser Id);
        bool Update(SaviourRDUser item);
        SaviourRDUser Get(int id);
        IEnumerable<SaviourRDUser> GetAll();
    }
}
