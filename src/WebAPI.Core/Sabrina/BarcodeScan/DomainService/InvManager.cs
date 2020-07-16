

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
using WebAPI.Sabrina.barcodeScan;


namespace WebAPI.Sabrina.barcodeScan.DomainService
{
    /// <summary>
    /// inv领域层的业务管理
    ///</summary>
    public class InvManager :WebAPIDomainServiceBase, IInvManager
    {
		
		private readonly IRepository<Inv,long> _repository;

		/// <summary>
		/// inv的构造方法
		///</summary>
		public InvManager(
			IRepository<Inv, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void Initinv()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
