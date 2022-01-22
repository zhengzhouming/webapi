
using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using L._52ABP.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Sabrina.MesWorkTagScan.Dtos;
using WebAPI.Sabrina.MesWorkTagScan;



namespace WebAPI.Sabrina.MesWorkTagScan
{
    /// <summary>
    /// 应用层服务的接口方法
    ///</summary>
    public interface IMesWorkTagScanAppService : IApplicationService
    {
        /// <summary>
		/// 获取的分页列表集合
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<MesWorkTagScanListDto>> GetPaged(GetMesWorkTagScansInput input);


		/// <summary>
		/// 通过指定id获取ListDto信息
		/// </summary>
		Task<MesWorkTagScanListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetMesWorkTagScanForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateMesWorkTagScanInput input);


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

        Task<List<MesWorkTagScanEditDto>> GetByTagInvoice(string tagInvoice);

        Task<List<MesWorkTagScanEditDto>> GetByTagNumber(int InOrOut, int scanDeptID, string tagNumber);

        Task<List<MesWorkTagScanEditDto>> GetByTagLocation(string tagLocation, int deptId, int InOrOut); 
    }
}
