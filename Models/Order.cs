using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please Enter First Address Line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage =("Please Enter a Ciry Name"))]
        public string City { get; set; }
        [Required(ErrorMessage = ("Please Enter a State Name"))]
        public string State { get; set; }
        public int Zip { get; set; }
        [Required(ErrorMessage = ("Please Enter a Country Name"))]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }


    }
}
