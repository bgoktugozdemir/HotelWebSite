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
    
    public partial class Posts
    {
        public int ID { get; set; }
        public Nullable<int> OrderSort { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string HeaderText { get; set; }
        public string BodyText { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public System.DateTime CreatedAt { get; set; }
    
        public virtual Employees Employees { get; set; }
    }
}
