//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel.Model.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Testimonials
    {
        public int ID { get; set; }
        public int OrderSort { get; set; }
        public string Image { get; set; }
        public double Rate { get; set; }
        public string Message { get; set; }
        public bool IsShow { get; set; }
        public int CustomerID { get; set; }
        public int BookID { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Customers Customers { get; set; }
    }
}
