using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.AOP
{
   public class User_Setup
    {
        [Key]
       public long    ID { get; set; }
       public string    UserName { get; set; }
        public string  Password { get; set; }
        public long    Status { get; set; }


    }
}
