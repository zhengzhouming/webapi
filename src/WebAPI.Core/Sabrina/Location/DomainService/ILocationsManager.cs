

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using WebAPI.Sabrina.Locations;


namespace WebAPI.Sabrina.Locations.DomainService
{
    public interface ILocationsManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitLocations();



		 
      
         

    }
}
