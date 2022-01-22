using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Sabrina.MesDept
{
    public class MesDept : Entity<long>
    {
        public string DeptName { get; set; }
        public string DeptNumber { get; set; }
        public string Marsk { get; set; }
    }
}
