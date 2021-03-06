//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servier.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Advance
    {
        public Advance()
        {
            this.AdvanceDetails = new HashSet<AdvanceDetail>();
        }
    
        public int AdvanceID { get; set; }
        public int Period { get; set; }
        public int Year { get; set; }
        public Nullable<int> SectorID { get; set; }
        public string Comment { get; set; }
        public Nullable<int> ProcessLevel { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        public virtual ICollection<AdvanceDetail> AdvanceDetails { get; set; }
    }
}
