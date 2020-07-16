
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
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using WebAPI.Sabrina.Locations;
using WebAPI.Sabrina.Locations.Dtos;
using WebAPI.Sabrina.Locations.DomainService;
using WebAPI.Sabrina.Locations.Authorization;
using Microsoft.EntityFrameworkCore.Internal;
using Abp.Organizations;
using NPOI.SS.Formula.Functions;
using Abp.EntityFrameworkCore.Repositories;

namespace WebAPI.Sabrina.Locations
{
    /// <summary>
    /// Locations应用层服务的接口实现方法  
    ///</summary>
    //[AbpAuthorize]
    public class LocationsAppService : WebAPIAppServiceBase, ILocationsAppService
    {
        private readonly IRepository<Locations, long> _entityRepository;

        private readonly ILocationsManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public LocationsAppService(
        IRepository<Locations, long> entityRepository
        ,ILocationsManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取Locations的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(LocationsPermissions.Query)] 
        public async Task<PagedResultDto<LocationsListDto>> GetPaged(GetLocationssInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件           

			var count = await query.CountAsync();
			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<LocationsListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<LocationsListDto>>();
			return new PagedResultDto<LocationsListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取LocationsListDto信息
		/// </summary>
		//[AbpAuthorize(LocationsPermissions.Query)] 
		public async Task<LocationsListDto> GetById(EntityDto<long> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<LocationsListDto>();
		}




		/// <summary>
		/// 通过指定Org厂区获取LocationsListDto信息
		/// </summary>
		//      [AbpAuthorize(DocpacklistPermissions.Query)]
		public async Task<PagedResultDto<LocationsListDto>> GetByOrg(string Org)
		{
			 

			var query = _entityRepository.GetAll().AsNoTracking()
				.Where(a => a.Org.Equals(Org));

			// TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();
			var entityList = await query
					.OrderBy(a => a.Id).Distinct().ToListAsync();
			var entityListDtos = entityList.MapTo<List<LocationsListDto>>();
			return new PagedResultDto<LocationsListDto>(count, entityListDtos);
			 
		}


		/// <summary>
		/// 获取编辑 Locations
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(LocationsPermissions.Create,LocationsPermissions.Edit)]
		public async Task<GetLocationsForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetLocationsForEditOutput();
LocationsEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<LocationsEditDto>();

				//locationsEditDto = ObjectMapper.Map<List<locationsEditDto>>(entity);
			}
			else
			{
				editDto = new LocationsEditDto();
			}

			output.Locations = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改Locations的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(LocationsPermissions.Create,LocationsPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateLocationsInput input)
		{

			if (input.Locations.Id.HasValue)
			{
				await Update(input.Locations);
			}
			else
			{
				await Create(input.Locations);
			}
		}


		/// <summary>
		/// 新增Locations
		/// </summary>
		//[AbpAuthorize(LocationsPermissions.Create)]
		protected virtual async Task<LocationsEditDto> Create(LocationsEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Locations>(input);
            var entity=input.MapTo<Locations>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<LocationsEditDto>();
		}

		/// <summary>
		/// 编辑Locations
		/// </summary>
		//[AbpAuthorize(LocationsPermissions.Edit)]
		protected virtual async Task Update(LocationsEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除Locations信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(LocationsPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Locations的方法
		/// </summary>
		//[AbpAuthorize(LocationsPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出Locations为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


