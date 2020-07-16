
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


using WebAPI.Sabrina.Locations.Dtos;
using WebAPI.Sabrina.Locations;

namespace WebAPI.Sabrina.Locations
{
    /// <summary>
    /// Locations应用层服务的接口方法
    ///</summary>
    public interface ILocationsAppService : IApplicationService
    {
        /// <summary>
		/// 获取Locations的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<LocationsListDto>> GetPaged(GetLocationssInput input);


		/// <summary>
		/// 通过指定id获取LocationsListDto信息
		/// </summary>
		Task<LocationsListDto> GetById(EntityDto<long> input);

        /// <summary>
        /// 通过指定Org厂区获取LocationsListDto信息
        /// </summary>
        Task<PagedResultDto<LocationsListDto>> GetByOrg(string Org);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetLocationsForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改Locations的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateLocationsInput input);


        /// <summary>
        /// 删除Locations信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除Locations
        /// </summary>
        Task BatchDelete(List<long> input);


		/// <summary>
        /// 导出Locations为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
