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
    
    public partial class Hospital
    {
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }
        public int HospitalType { get; set; }
        public Nullable<int> SectorID { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
    
        public virtual Sector Sector { get; set; }
    }
}
