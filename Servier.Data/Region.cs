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
    
    public partial class Region
    {
        public Region()
        {
            this.Sectors = new HashSet<Sector>();
        }
    
        public int RegionID { get; set; }
        public string RegionName { get; set; }
        public Nullable<int> Rank { get; set; }
        public string Note { get; set; }
    
        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
