

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using WebAPI.Sabrina.barcodeScan;


namespace WebAPI.Sabrina.barcodeScan.DomainService
{
    public interface IInvManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void Initinv();



		 
      
         

    }
}
