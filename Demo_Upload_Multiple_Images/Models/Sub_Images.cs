//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo_Upload_Multiple_Images.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Sub_Images
    {
        public int id { get; set; }
        public string url_images { get; set; }
        public Nullable<int> product_id { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
