
using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using L._52ABP.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Sabrina.MesWorkTagScanReceipt.Dtos;
using WebAPI.Sabrina.MesWorkTagScanReceipt;



namespace WebAPI.Sabrina.MesWorkTagScanReceipt
{
    /// <summary>
    /// 应用层服务的接口方法
    ///</summary>
    public interface IMesWorkTagScanReceiptAppService : IApplicationService
    {
        /// <summary>
		/// 获取的分页列表集合
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<MesWorkTagScanReceiptListDto>> GetPaged(GetMesWorkTagScanReceiptsInput input);


		/// <summary>
		/// 通过指定id获取ListDto信息
		/// </summary>
		Task<MesWorkTagScanReceiptListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetMesWorkTagScanReceiptForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateMesWorkTagScanReceiptInput input);


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

        Task<PagedResultDto<MesWorkTagScanReceiptListDto>> GetMaxVersion();



                            //// custom codes



        //// custom codes end
    }
}
