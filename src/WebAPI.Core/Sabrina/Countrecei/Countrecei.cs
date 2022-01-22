using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Sabrina.Countrecei
{
    public class Countrecei : Entity<long>
    {
        /// <summary>
        /// 厂区
        /// </summary>
        public string Org { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        public string Subinv { get; set; }
        /// <summary>
        /// 线别
        /// </summary>
        public string line { get; set; }
        /// <summary>
        /// 款式
        /// </summary>
        public string style { get; set; }
        /// <summary>
        /// 款式数量
        /// </summary>
        public string StyleCount { get; set; }
        /// <summary>
        /// 手工入库数量
        /// </summary>
        public string  qtyCount { get; set; }

        /// <summary>
        /// 扫描入库数量
        /// </summary>
        public string ScanQtyCount { get; set; }

        /// <summary>
        /// 差异数量 -- 已入库还没有条码的
        /// </summary>
        public string DifferenceQtyCount { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public string receiInDate { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }
    }
}
