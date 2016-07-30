using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Newtonsoft.Json;

namespace SaviourRedDrop.Models
{
    public class SaviourRDUser
    {
      

        public int Id { set; get; }
        //[DisplayName("Email")]
        //[Required(ErrorMessage ="Please enter your Email Address")]
        //[DataType(DataType.EmailAddress)]
        //[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}",ErrorMessage ="Please enter correct Email Address" )]
        public string UserName { set; get; }
       // [Required (ErrorMessage ="User Name is Required ")]
        public string Name { set; get;  }

        [JsonIgnore]
        public string Password { set; get; }

        public int ReviewStatus { set; get; }
        public int BGId { set; get; }


        public string appUserId { set; get; }

        
        [ForeignKey("BGId")]
        public virtual BloodGroup BloodGroup { get; set; }

        public int Area { set; get; }

      

        [ForeignKey("Area")]
        public virtual City City { get; set; }
         //   [Required]
       //      [StringLength(10,MinimumLength =10,ErrorMessage ="Plz Enter the correct Number")]
        public string PhoneNumber { set; get; }
        [JsonIgnore]
        public virtual ICollection<Review> Reviews { set; get; }

   //     [JsonIgnore]
    //    public ApplicationUser Srd { set; get; }

    }
}