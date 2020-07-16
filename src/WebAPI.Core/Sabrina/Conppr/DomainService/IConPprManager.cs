

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using WebAPI.Sabrina.Conppr;


namespace WebAPI.Sabrina.Conppr.DomainService
{
    public interface IConPprManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitConPpr();



		 
      
         

    }
}
