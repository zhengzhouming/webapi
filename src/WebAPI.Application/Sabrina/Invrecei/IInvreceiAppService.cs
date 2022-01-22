
using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using L._52ABP.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Sabrina.Invrecei.Dtos;
using WebAPI.Sabrina.Invrecei;



namespace WebAPI.Sabrina.Invrecei
{
    /// <summary>
    /// 应用层服务的接口方法
    ///</summary>
    public interface IInvreceiAppService : IApplicationService
    {
        /// <summary>
		/// 获取的分页列表集合
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<InvreceiListDto>> GetPaged(GetInvreceisInput input);


		/// <summary>
		/// 通过指定id获取ListDto信息
		/// </summary>
		Task<InvreceiListDto> GetById(EntityDto<long> input);


        /// <summary>
		/// 通过指定条码号获取InvreceiListDto信息
		/// </summary>
        Task<List<InvreceiListDto>> GetTagNumber(string tagNumber);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetInvreceiForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateInvreceiInput input);


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
