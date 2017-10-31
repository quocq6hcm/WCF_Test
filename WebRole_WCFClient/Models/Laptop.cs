using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebRole_WCFClient.Models
{
    public class Laptop
    {    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required]
         [StringLength(30)]
         public string Title { get; set; }

        [Required]
          [StringLength(30)]
            public string Director { get; set; }

            [Required]
            public int YearOfRelease { get; set; }
        
    }
}