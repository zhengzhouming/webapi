
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


using WebAPI.Sabrina.barcodeScan;
using WebAPI.Sabrina.barcodeScan.Dtos;
using WebAPI.Sabrina.barcodeScan.DomainService;
using WebAPI.Sabrina.barcodeScan.Authorization;
using NPOI.SS.Formula.Functions;
using Masuit.Tools.Mapping.Extensions;

namespace WebAPI.Sabrina.barcodeScan
{
    /// <summary>
    /// inv应用层服务的接口实现方法  
    ///</summary>
    //[AbpAuthorize]
    public class InvAppService : WebAPIAppServiceBase, IinvAppService
    {
        private readonly IRepository<Inv, long> _entityRepository;

        private readonly IInvManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public InvAppService(
        IRepository<Inv, long> entityRepository
        ,IInvManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取inv的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(invPermissions.Query)] 
        public async Task<PagedResultDto<invListDto>> GetPaged(GetinvsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<invListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<invListDto>>();

			return new PagedResultDto<invListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 按TagNumber 获取外箱标的 订单信息
		///</summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(invPermissions.Query)] 
		public async Task<PagedResultDto<invListDto>> GetInvByTagNumbers(GetinvsInput input)
		{

			var query = _entityRepository.GetAll().AsNoTracking()
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.TagNumber.Contains(input.FilterText));
				
			 
			  var count = await query.CountAsync();
			var entityList = await query
				.OrderBy(a=>a.Scantime)	

					//.OrderBy(input.Sorting).AsNoTracking()			
					//.PageBy(input)
					.ToListAsync();
			var entityListDtos = entityList.MapTo<List<invListDto>>();	
			return new PagedResultDto<invListDto>(count, entityListDtos);
		}


		/// <summary>
		/// 根据 cust_id and  Serial_From 获取本箱信息
		/// </summary>
		/// <param name="tagNumber"> 箱号 </param>
		/// <returns></returns>
		public async Task<List<invListDto>> GetInvByTagNumber(string tagNumber)
		{

			var entityListDtos = new List<invListDto>();
			if (tagNumber.IsNullOrWhiteSpace()) { return null; }
			var query = _entityRepository.GetAll().AsNoTracking()
			.WhereIf(!tagNumber.IsNullOrWhiteSpace(), a => a.TagNumber.Equals(tagNumber));

			var entityList = await query.OrderBy(a => a.Id).OrderByDescending(a=>a.Scantime).ToListAsync();
			entityListDtos = ObjectMapper.Map<List<invListDto>>(entityList);
			return entityListDtos;
		}


		/// <summary>
		/// 根据  con_no 获取本箱信息
		/// </summary>
		/// <param name="con_no"> 箱号 </param>
		/// <returns></returns>
		public async Task<List<invListDto>> GetInvByConNo(string conNo)
		{

			var entityListDtos = new List<invListDto>();
			if (conNo.IsNullOrWhiteSpace()) { return null; }
			var query = _entityRepository.GetAll().AsNoTracking()
			.WhereIf(!conNo.IsNullOrWhiteSpace(), a => a.Con_no.Equals(conNo));
			var entityList = await query.OrderByDescending(a =>a.Scantime)
				.ToListAsync();
			entityListDtos = ObjectMapper.Map<List<invListDto>>(entityList);
			return entityListDtos;
		}

		/// <summary>
		/// 通过指定id获取invListDto信息
		/// </summary>
		//[AbpAuthorize(invPermissions.Query)] 
		public async Task<invListDto> GetById(EntityDto<long> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<invListDto>();
		}

		/// <summary>
		/// 获取编辑 inv
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(invPermissions.Create,invPermissions.Edit)]
		public async Task<GetinvForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetinvForEditOutput();
invEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<invEditDto>();

				//invEditDto = ObjectMapper.Map<List<invEditDto>>(entity);
			}
			else
			{
				editDto = new invEditDto();
			}

			output.inv = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改inv的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(invPermissions.Create,invPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateinvInput input)
		{

			if (input.inv.Id.HasValue)
			{
				await Update(input.inv);
			}
			else
			{
				await Create(input.inv);
			}
		}


		/// <summary>
		/// 新增inv
		/// </summary>
		//[AbpAuthorize(invPermissions.Create)]
		protected virtual async Task<invEditDto> Create(invEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <inv>(input);
            var entity=input.MapTo<Inv>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<invEditDto>();
		}

		/// <summary>
		/// 编辑inv
		/// </summary>
		//[AbpAuthorize(invPermissions.Edit)]
		protected virtual async Task Update(invEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除inv信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(invPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除inv的方法
		/// </summary>
		//[AbpAuthorize(invPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出inv为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}


		/// <summary>
		/// 根据 cust_id and  Serial_From 获取本箱信息
		/// </summary>
		/// <param name="tagNumber"> 箱号 </param>
		/// <returns></returns>
		 

	}
}


