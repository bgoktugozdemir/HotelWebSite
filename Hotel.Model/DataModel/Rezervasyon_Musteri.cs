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
    
    public partial class Rezervasyon_Musteri
    {
        public int Id { get; set; }
        public int RezervasyonId { get; set; }
        public int MusteriId { get; set; }
    
        public virtual Musteri Musteri { get; set; }
        public virtual Rezervasyon Rezervasyon { get; set; }
    }
}