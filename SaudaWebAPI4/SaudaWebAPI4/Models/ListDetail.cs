//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaudaWebAPI4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListDetail()
        {
            this.ListStoreAssociations = new HashSet<ListStoreAssociation>();
        }
    
        public int ListDetailID { get; set; }
        public int ListHeaderID { get; set; }
        public int ItemID { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemTotal { get; set; }
        public bool ItemActive { get; set; }
    
        public virtual ListHeader ListHeader { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListStoreAssociation> ListStoreAssociations { get; set; }
    }
}
