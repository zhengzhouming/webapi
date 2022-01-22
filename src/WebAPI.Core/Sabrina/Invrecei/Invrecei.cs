using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Sabrina.Invrecei
{
    public class Invrecei : Entity<long>
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
        /// 外箱条码
        /// </summary>
        public string TagNumber { get; set; }

        /// <summary>
        /// 箱重
        /// </summary>
        public string kg { get; set; }

        /// <summary>
        /// 扫描时间
        /// </summary>
        public string scantime { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public string update_date { get; set; }

        /// <summary>
        /// 上传PDA
        /// </summary>
        public string create_pc { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string exeStatus { get; set; }
    }
}
