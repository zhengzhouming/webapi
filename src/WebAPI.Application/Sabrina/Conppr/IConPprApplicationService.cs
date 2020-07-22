
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using WebAPI.Sabrina.Conppr.Dtos;
using WebAPI.Sabrina.Conppr;
using static WebAPI.Sabrina.Conppr.ConPprAppService;

namespace WebAPI.Sabrina.Conppr
{
    /// <summary>
    /// ConPpr应用层服务的接口方法
    ///</summary>
    public interface IConPprAppService : IApplicationService
    {
        /// <summary>
		/// 获取ConPpr的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ConPprListDto>> GetPaged(GetConPprsInput input);


         Task<List<ConPprListDto>> GetBoxByPPrfNo(string PPrfNo);
         Task<List<ConPprListDto>> GetBoxBySerial_From(string serial_From, string cust_id);


        /// <summary>
        /// 通过指定id获取ConPprListDto信息
        /// </summary>
        Task<ConPprListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetConPprForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改ConPpr的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateConPprInput input);


        /// <summary>
        /// 删除ConPpr信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除ConPpr
        /// </summary>
        Task BatchDelete(List<long> input);

         List<OrderInfos> getOrderByTagNumber(string tagNumber);

          List<StockInfos> getStockByTagNumber(string tagNumber);



    }
}
