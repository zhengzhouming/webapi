
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;


namespace WebAPI.Sabrina.Countrecei.DomainService
{
    public interface ICountReceiManager : IDomainService
    {


		/// <summary>
		/// 返回表达式数的实体信息即IQueryable类型
		/// </summary>
		/// <returns></returns>
		IQueryable<Countrecei> QueryCountReceis();

		/// <summary>
		/// 返回性能更好的IQueryable类型，但不包含EF Core跟踪标记
		/// </summary>
		/// <returns></returns>

		IQueryable<Countrecei> QueryCountReceisAsNoTracking();

		/// <summary>
		/// 根据Id查询实体信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Countrecei> FindByIdAsync(long id);
	
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
		Task<Countrecei> CreateAsync(Countrecei entity);

		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		Task UpdateAsync(Countrecei entity);

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
