//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IBMClinicAutomationApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class patientReport
    {
        public int reportID { get; set; }
        public int patientID { get; set; }
        public string reportType { get; set; }
        public Nullable<System.DateTime> reportDate { get; set; }
        public string reportDetails { get; set; }
    
        public virtual patient patient { get; set; }
    }
}
