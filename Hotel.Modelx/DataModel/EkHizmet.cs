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
    
    public partial class EkHizmet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EkHizmet()
        {
            this.Fiyat = new HashSet<Fiyat>();
            this.Oda_EkHizmet = new HashSet<Oda_EkHizmet>();
            this.Rezervasyon_EkHizmet = new HashSet<Rezervasyon_EkHizmet>();
        }
    
        public int Id { get; set; }
        public string Ad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fiyat> Fiyat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oda_EkHizmet> Oda_EkHizmet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervasyon_EkHizmet> Rezervasyon_EkHizmet { get; set; }
    }
}
