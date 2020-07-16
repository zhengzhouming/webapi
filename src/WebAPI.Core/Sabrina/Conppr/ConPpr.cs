using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Sabrina.Conppr
{
    public class ConPpr : Entity<long>
    {
        /// <summary>
        /// con_ppr的ID
        /// </summary>
        public string PPR_id { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public string Cust_id { get; set; }

        /// <summary>
        /// 外箱号
        /// </summary>
        public string Serial_From { get; set; }

        /// <summary>
        /// 件数
        /// </summary>
        public int? Qty { get; set; }

        /// <summary>
        /// 厂区
        /// </summary>
        public string Org { get; set; }

        /// <summary>
        /// 计划参考号码
        /// </summary>
        public string PPrfNo { get; set; }

        /// <summary>
        /// 本装箱方式箱数  
        /// </summary>
        public int? Count1 { get; set; }

        /// <summary>
        /// 创建者电脑名
        /// </summary>
        public string Create_Pc { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? Update_Date { get; set; }

        /// <summary>
        /// 箱号
        /// </summary>
        public int? Con_no { get; set; }

        /// <summary>
        ///  未知？
        /// </summary>
        public string Country_Code { get; set; }

        /// <summary>
        /// 本装箱方式结束箱号  
        /// </summary>
        public int? Con_To { get; set; }

        //**************************************************

        /// <summary>
        /// 外箱代码  
        /// </summary>
        public string Pkg_Code { get; set; }


        /// <summary>
        /// 什么的扫描ID  
        /// </summary>
        public string Scan_ID { get; set; }

        /// <summary>
        ///  不知道什么的值  不重要
        /// </summary>
        public float? Net_Net { get; set; }

        /// <summary>
        ///  不知道什么的值  不重要
        /// </summary>
        public float? Con_Net { get; set; }

        /// <summary>
        ///  不知道什么的值  不重要
        /// </summary>
        public float? Con_Gross { get; set; }

        /// <summary>
        ///  不知道什么的值  不重要
        /// </summary>
        public float? Con_L { get; set; }
        /// <summary>
        ///  不知道什么的值  不重要
        /// </summary>
        public float? Con_W { get; set; }
        /// <summary>
        ///  不知道什么的值  不重要
        /// </summary>
        public float? Con_H { get; set; }

        /// <summary>
        ///  不知道什么的值  不重要
        /// </summary>
        public float? B_Volume { get; set; }
        /// <summary>
        ///  不知道什么的值  不重要
        /// </summary>
        public string PO { get; set; }
        /// <summary>
        ///  不知道什么的值  不重要
        /// </summary>
        public string MAIN_LINE { get; set; }


    
}
}
