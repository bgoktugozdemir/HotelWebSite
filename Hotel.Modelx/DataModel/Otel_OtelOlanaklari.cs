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
    
    public partial class Otel_OtelOlanaklari
    {
        public int Id { get; set; }
        public int OtelId { get; set; }
        public int OtelOlanaklariId { get; set; }
    
        public virtual Otel Otel { get; set; }
        public virtual OtelOlanaklari OtelOlanaklari { get; set; }
    }
}
