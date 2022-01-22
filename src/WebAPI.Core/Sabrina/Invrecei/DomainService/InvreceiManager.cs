

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Sabrina.Invrecei.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class InvreceiManager :WebAPIDomainServiceBase, IInvreceiManager
    {
		
		private readonly IRepository<Invrecei,long> _invreceiRepository;

		/// <summary>
		/// Invrecei的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	public InvreceiManager(IRepository<Invrecei, long> invreceiRepository)	{
			_invreceiRepository =  invreceiRepository;
		}

		 #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<Invrecei> QueryInvreceis()
        {
            return _invreceiRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<Invrecei> QueryInvreceisAsNoTracking()
        {
            return _invreceiRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Invrecei> FindByIdAsync(long id)
        {
            var entity = await _invreceiRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _invreceiRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion

		 
		 
        public async Task<Invrecei> CreateAsync(Invrecei entity)
        {
            entity.Id = await _invreceiRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Invrecei entity)
        {
            await _invreceiRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _invreceiRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _invreceiRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	 
			
							//// custom codes
									
							

							//// custom codes end



		 
		  
		 

	}
}
