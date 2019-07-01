//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public Cart()
        {
            this.CartProducts = new HashSet<CartProduct>();
            this.Orders = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        public int MemberId { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string ShippingCost { get; set; }
        public System.DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
