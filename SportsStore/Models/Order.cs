﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int   OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }= new List<CartLine>();
        [Required(ErrorMessage ="Please enter a name")]
        [BindNever]
        public bool Shipped { get; set; }   
        public string? Name { get; set; }
        [Required(ErrorMessage ="Please enter the First address Line")]
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        [Required(ErrorMessage ="please enter a city name")]
        public string? City { get; set; }
        [Required(ErrorMessage = "please enter a State name")]
        public string? State { get; set; }
        public string? Zip {  get; set; }
        [Required(ErrorMessage = "please enter a Country name")]
        public string? Country { get; set; }
        public bool GiftWrap    { get; set; }   

    }
}
