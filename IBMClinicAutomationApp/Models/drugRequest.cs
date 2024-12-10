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
    
    public partial class drugRequest
    {
        public int requestID { get; set; }
        public Nullable<int> requestedBy { get; set; }
        public Nullable<int> requestedFor { get; set; }
        public Nullable<int> drugID { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<System.DateTime> requestDate { get; set; }
        public string requestStatus { get; set; }
        public Nullable<int> supplierID { get; set; }
        public string Note { get; set; }
    
        public virtual drug drug { get; set; }
        public virtual physician physician { get; set; }
        public virtual patient patient { get; set; }
        public virtual supplier supplier { get; set; }
    }
}
