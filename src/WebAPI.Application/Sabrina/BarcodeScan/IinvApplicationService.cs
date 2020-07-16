
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


using WebAPI.Sabrina.barcodeScan.Dtos;
using WebAPI.Sabrina.barcodeScan;

namespace WebAPI.Sabrina.barcodeScan
{
    /// <summary>
    /// inv应用层服务的接口方法
    ///</summary>
    public interface IinvAppService : IApplicationService
    {
        /// <summary>
		/// 获取inv的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<invListDto>> GetPaged(GetinvsInput input);

        /// <summary>
        /// 获取inv的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<invListDto>> GetInvByTagNumbers(GetinvsInput input);
        Task<List<invListDto>> GetInvByTagNumber(string tagNumber);
        //   Task<invListDto> GetInvByTagNumber(string tagNumber);

        Task<List<invListDto>> GetInvByConNo(string conNo);

        /// <summary>
        /// 通过指定id获取invListDto信息
        /// </summary>
        Task<invListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetinvForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改inv的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateinvInput input);


        /// <summary>
        /// 删除inv信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除inv
        /// </summary>
        Task BatchDelete(List<long> input);


		/// <summary>
        /// 导出inv为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
