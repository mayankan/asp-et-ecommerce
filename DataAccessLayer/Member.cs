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
    
    public partial class Member
    {
        public Member()
        {
            this.Carts = new HashSet<Cart>();
        }
    
        public int Id { get; set; }
        public bool IsGuest { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public int AddressId { get; set; }
        public bool Gender { get; set; }
        public bool IsDeleted { get; set; }
        public string Password { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
