using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Sabrina.MesWorkTagScan
{
   public  class MesWorkTagScan : Entity<long>
    {
        /// <summary>
        /// 工票扫描
        /// </summary>

        //送货单号
        public string tagInvoice { get; set; }

        //送货单版本号
        public int tagInvoiceVersion { get; set; }

        //收货单号
        public string tagReceiptNumber { get; set; }

        //储位号码
        public string tagLocation { get; set; }

        //工票号码
        public string tagNumber { get; set; }

        //扫描账号
        public string tagScanAccount { get; set; }

        //作业部门ID
        public int tagScanDeptID { get; set; }

        // 报工厂区
        public string tagOrg { get; set; }

        // 报工线别
        public string tagLine { get; set; }

        //扫描时间
        public string tagScanDateTime { get; set; }

        //上传时间
        public string tagUploadDateTime { get; set; }

        //扫描枪Serial
        public string tagScanPDASerial { get; set; }

        //扫描枪UUID
        public string tagScanPDAUUID { get; set; }

        //扫描类别: 0入库  1 出库 
        public int isInOrOut { get; set; }

        //款式
        public string tagStyle { get; set; }

        //颜色
        public string tagColor { get; set; }

        //尺码
        public string tagSize { get; set; }

        //数量
        public int tagQty { get; set; }


        //PDA 上传与否: 0未上传  1 已上传 
        public int isUploaded { get; set; }

        //资料同步MES库与否: 0未同步  1 已同步 
        public int isSyncMesData { get; set; }

        //已打印次数
        public int isPrints { get; set; }

        //是否已删除: 0有效  -1 已删除 
        public int isDels { get; set; }



    }
}
