using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Sabrina.MesWorkTagScanReceipt
{
    public class MesWorkTagScanReceipt : Entity<long>
    {
        /// <summary>
        /// 工票扫描批号服务
        /// </summary>

        //送货单号 版本号
        public string Version { get; set; }        

        //创建账号
        public string tagScanAccount { get; set; }

        //创建部门ID
        public int tagScanDeptID { get; set; }

        //创建时间
        public string tagScanDateTime { get; set; }       

        //扫描枪Serial
        public string tagScanPDASerial { get; set; }

        //扫描枪UUID
        public string tagScanPDAUUID { get; set; }

    }
}
