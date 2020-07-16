
    using Abp.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace WebAPI.Sabrina.Locations
    {
        public class Locations : Entity<long>
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
            /// 储位
            /// </summary>
            public string Location { get; set; }
            /// <summary>
            /// 大小
            /// </summary>
            public float? L_Size { get; set; }
            /// <summary>
            /// 位置 X
            /// </summary>
            public int? X_location { get; set; }
            /// <summary>
            /// 位置 Y
            /// </summary>
            public int? Y_location { get; set; }
            /// <summary>
            /// 创建人
            /// </summary>
            public string Create_pc { get; set; }
            /// <summary>
            /// 更新时间
            /// </summary>
            public DateTime? Update_date { get; set; }
        }
    }


