using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IBMClinicAutomationApp.Models
{

    [MetadataType(typeof(ValidationConfigForAdvice))]
    public partial class advice
    { 
    }


        public class ValidationConfigForAdvice
    {
        [Required]
        public string advice1 { get; set; }



    }


    [MetadataType(typeof(ValidationConfigForPrescription))]
    public partial class prescription
    { }

        public partial class ValidationConfigForPrescription
    {

        [Required ]
        [RegularExpression("[A-Za-z0-9 ]*") ]
        public string dosage { get; set; }
        [Required]
        [StringLength (200)]
        public string note { get; set; }

       
    }



}