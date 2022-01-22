using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Sabrina.Recei
{
   
    public class Recei : Entity<long>
    {

        /// <summary>
        /// 厂区
        /// </summary>
        public string org { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public string subinv { get; set; }

        /// <summary>
        /// 线别
        /// </summary>
        public string line { get; set; }

        /// <summary>
        /// 款式
        /// </summary>
        public string style { get; set; }

        /// <summary>
        /// 色组
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// 尺码
        /// </summary>
        public string size { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public int? qtyCount { get; set; }

        /// <summary>
        /// 原来是PO  现在用来写入扫描条码的件数 满了写ISFULL=1
        /// </summary>
        public string po { get; set; }

        /// <summary>
        /// 箱数
        /// </summary>
        public string boxCount { get; set; }

        /// <summary>
        /// 送货单号
        /// </summary>
        public string receiNumber { get; set; }
        /// <summary>
        /// 送货单日期
        /// </summary>
        public string receiDate { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string receiEmp { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string mark { get; set; }
        /// <summary>
        /// 录入系统日期
        /// </summary>
        public string receiInDate { get; set; }
        /// <summary>
        /// 录入系统电脑名称
        /// </summary>
        public string receiInPcName { get; set; }
        /// <summary>
        /// 状态 0 无条码入库 1 条码扫满
        /// </summary>
        public int? isFull { get; set; }
    }
}
