
using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using L._52ABP.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Sabrina.Recei.Dtos;
using WebAPI.Sabrina.Recei;



namespace WebAPI.Sabrina.Recei
{
    /// <summary>
    /// 应用层服务的接口方法
    ///</summary>
    public interface IReceiAppService : IApplicationService
    {
        /// <summary>
		/// 获取的分页列表集合
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ReceiListDto>> GetPaged(GetReceisInput input);


		/// <summary>
		/// 通过指定id获取ListDto信息
		/// </summary>
		Task<ReceiListDto> GetById(EntityDto<long> input);

        Task<List<ReceiListDto>> getOutCountQty(string org, string subinv, string line, string style, string color, string size);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetReceiForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateReceiInput input);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);

		
        /// <summary>
        /// 批量删除
        /// </summary>
        Task BatchDelete(List<long> input);


		
							//// custom codes
									
							

							//// custom codes end
    }
}
