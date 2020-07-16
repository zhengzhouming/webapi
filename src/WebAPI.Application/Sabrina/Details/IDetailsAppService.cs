
using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using L._52ABP.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Sabrina.Details.Dtos;
using WebAPI.Sabrina.Details;



namespace WebAPI.Sabrina.Details
{
    /// <summary>
    /// 应用层服务的接口方法
    ///</summary>
    public interface IDetailsAppService : IApplicationService
    {
        /// <summary>
		/// 获取的分页列表集合
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<DetailsListDto>> GetPaged(GetDetailssInput input);


		/// <summary>
		/// 通过指定id获取ListDto信息
		/// </summary>
		Task<DetailsListDto> GetById(EntityDto<long> input);

        /// <summary>
		/// 通过指定PPrfNo获取ListDto信息
		/// </summary>
        Task<List<DetailsListDto>> GetBoxByPPrfNo(string PPrfNo);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetDetailsForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateDetailsInput input);


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
