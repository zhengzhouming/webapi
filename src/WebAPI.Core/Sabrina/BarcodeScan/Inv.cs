using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Sabrina.barcodeScan
{
   public  class Inv : Entity<long>
    {
        /// <summary>
        /// 外箱条码号
        /// </summary>
        public string TagNumber { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public string Cust_id { get; set; }

        /// <summary>
        /// 仓位
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 上传日期时间
        /// </summary>
        public DateTime Update_date { get; set; }

        /// <summary>
        /// 厂区 SAA / TOP
        /// </summary>
        public string Org { get; set; }

        /// <summary>
        /// 箱号  条码20位时从第11位开始截取长度9位 如果最高为为0时 删掉0  
        /// </summary>
        public string Con_no { get; set; } 

        /// <summary>
        /// 创建者电脑名
        /// </summary>
        public string Create_pc { get; set; }

        /// <summary>
        /// 箱重
        /// </summary>
        public float? KG { get; set; }

        /// <summary>
        /// 仓库代号
        /// </summary>
        public string Subinv { get; set; }

        /// <summary>
        ///  扫描时间
        /// </summary>
        public DateTime Scantime { get; set; }

        /// <summary>
        /// 状态?  常量 O
        /// </summary>
        public string ExeStatus { get; set; }


       
    }
}
