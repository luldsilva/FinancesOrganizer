using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAPI.Data.Requests
{
    public class ActiveAcountRequest
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public string CodeActivation { get; set; }
    }
}
