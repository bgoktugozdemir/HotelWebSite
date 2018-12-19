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
    
    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            this.Testimonials = new HashSet<Testimonials>();
        }
    
        public int ID { get; set; }
        public System.DateTime BookingDate { get; set; }
        public System.DateTime ArrivalDate { get; set; }
        public System.DateTime DepartureDate { get; set; }
        public int Night { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public int RoomID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public bool IsCheckIn { get; set; }
        public bool IsCancelled { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Rooms Rooms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Testimonials> Testimonials { get; set; }
    }
}
