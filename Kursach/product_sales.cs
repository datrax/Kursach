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
    
    public partial class product_sales
    {
        public int id_raw { get; set; }
        public System.DateTime date_of_sales { get; set; }
        public int amount { get; set; }
    
        public virtual raw raw { get; set; }
    }
}
