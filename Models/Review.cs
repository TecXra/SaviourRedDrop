using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;


namespace SaviourRedDrop.Models
{
    public class Review
    {
        public int Id { set; get; }
       // public string ReviewWriterId { set; get; }
        public int UserId { set; get; }
        public string FeedBack { set; get; }
        public int writerId { get; set; }

        [ForeignKey("UserId")]
        public virtual  SaviourRDUser user { get; set; }


    }
}