//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursach
{
    using System;
    using System.Collections.Generic;
    
    public partial class contract
    {
        public contract()
        {
            this.product_order = new HashSet<product_order>();
        }
    
        public int id_contract { get; set; }
        public Nullable<System.DateTime> number_month { get; set; }
        public Nullable<int> id_supp { get; set; }
    
        public virtual supplier supplier { get; set; }
        public virtual ICollection<product_order> product_order { get; set; }
    }
}
