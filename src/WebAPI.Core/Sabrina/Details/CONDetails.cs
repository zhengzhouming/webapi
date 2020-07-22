using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Sabrina.Details
{
    public  class CONDetails : Entity<long>
    {
       
        public string Detailid { get; set; }
       
        public string Custid { get; set; }
    
        public string SerialFrom { get; set; }
       
        public string BuyerItem { get; set; }
       
        public string Itemdesc { get; set; }
        
        public string Colorcode { get; set; }
        
        public string Size1 { get; set; }
        
        public int? ConQty { get; set; }
       
        public int? Qty { get; set; }
       
        public string Pprfno { get; set; }
    }
}
