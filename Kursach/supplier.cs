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
    
    public partial class supplier
    {
        public supplier()
        {
            this.contract = new HashSet<contract>();
        }
    
        public int id_supp { get; set; }
        public string name_supp { get; set; }
    
        public virtual ICollection<contract> contract { get; set; }
    }
}
