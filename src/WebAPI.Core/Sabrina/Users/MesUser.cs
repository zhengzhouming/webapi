using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Sabrina.Users
{
    public class MesUser : Entity<long>
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string account { get; set; }
        public string password { get; set; }
        public string userName { get; set; }
        public string deptID { get; set; }
        public string marsk { get; set; } 
    }
}
