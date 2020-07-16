

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
using WebAPI.Sabrina.Conppr;


namespace WebAPI.Sabrina.Conppr.DomainService
{
    /// <summary>
    /// ConPpr领域层的业务管理
    ///</summary>
    public class ConPprManager :WebAPIDomainServiceBase, IConPprManager
    {
		
		private readonly IRepository<ConPpr,long> _repository;

		/// <summary>
		/// ConPpr的构造方法
		///</summary>
		public ConPprManager(
			IRepository<ConPpr, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitConPpr()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
