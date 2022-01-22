
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;


namespace WebAPI.Sabrina.MesDept.DomainService
{
    public interface IMesDeptManager : IDomainService
    {


		/// <summary>
		/// 返回表达式数的实体信息即IQueryable类型
		/// </summary>
		/// <returns></returns>
		IQueryable<MesDept> QueryMesDepts();

		/// <summary>
		/// 返回性能更好的IQueryable类型，但不包含EF Core跟踪标记
		/// </summary>
		/// <returns></returns>

		IQueryable<MesDept> QueryMesDeptsAsNoTracking();

		/// <summary>
		/// 根据Id查询实体信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<MesDept> FindByIdAsync(long id);
	
		/// <summary>
		/// 检查实体是否存在
		/// </summary>
		/// <returns></returns>
		Task<bool> IsExistAsync(long id);


		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		Task<MesDept> CreateAsync(MesDept entity);

		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		Task UpdateAsync(MesDept entity);

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(long id);
		/// <summary>
		/// 批量删除
		/// </summary>
		/// <param name="input">Id的集合</param>
		/// <returns></returns>
		Task BatchDelete(List<long> input);


		
							//// custom codes
									
							

							//// custom codes end

		 
      
         

    }
}
