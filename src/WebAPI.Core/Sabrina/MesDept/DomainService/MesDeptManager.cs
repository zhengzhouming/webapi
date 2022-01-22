

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Sabrina.MesDept.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class MesDeptManager :WebAPIDomainServiceBase, IMesDeptManager
    {
		
		private readonly IRepository<MesDept,long> _MesDeptRepository;

		/// <summary>
		/// MesDept的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	public MesDeptManager(IRepository<MesDept, long> MesDeptRepository)	{
			_MesDeptRepository =  MesDeptRepository;
		}

		 #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<MesDept> QueryMesDepts()
        {
            return _MesDeptRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<MesDept> QueryMesDeptsAsNoTracking()
        {
            return _MesDeptRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MesDept> FindByIdAsync(long id)
        {
            var entity = await _MesDeptRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _MesDeptRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion

		 
		 
        public async Task<MesDept> CreateAsync(MesDept entity)
        {
            entity.Id = await _MesDeptRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(MesDept entity)
        {
            await _MesDeptRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _MesDeptRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _MesDeptRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	 
			
							//// custom codes
									
							

							//// custom codes end



		 
		  
		 

	}
}
