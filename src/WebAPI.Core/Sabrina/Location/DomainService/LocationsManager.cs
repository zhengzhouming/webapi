

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using WebAPI;
using WebAPI.Sabrina.Locations;


namespace WebAPI.Sabrina.Locations.DomainService
{
    /// <summary>
    /// Locations领域层的业务管理
    ///</summary>
    public class LocationsManager :WebAPIDomainServiceBase, ILocationsManager
    {
		
		private readonly IRepository<Locations,long> _repository;

		/// <summary>
		/// Locations的构造方法
		///</summary>
		public LocationsManager(
			IRepository<Locations, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitLocations()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
