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
    
    public partial class Otel_Calisan
    {
        public int Id { get; set; }
        public int OtelId { get; set; }
        public int CalisanId { get; set; }
        public decimal Maas { get; set; }
        public Nullable<System.DateTime> SilinmeTarihi { get; set; }
        public System.DateTime BaslangicTarihi { get; set; }
        public Nullable<System.DateTime> CikisTarihi { get; set; }
    
        public virtual Calisan Calisan { get; set; }
        public virtual Otel Otel { get; set; }
    }
}
