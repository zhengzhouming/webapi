
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.Domain.Repositories;
using L._52ABP.Application.Dtos;
using L._52ABP.Common.Extensions.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using WebAPI.Sabrina.Details;
using WebAPI.Sabrina.Details.Dtos;
using WebAPI.Sabrina.Details.DomainService;
using WebAPI.Authorization;

namespace WebAPI.Sabrina.Details
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
    //[AbpAuthorize]
    public class DetailsAppService : WebAPIAppServiceBase, IDetailsAppService
    {
         private readonly IRepository<CONDetails, long>        _detailsRepository;

        private readonly IDetailsManager _detailsManager;
        /// <summary>
        /// 构造函数
        ///</summary>
        public DetailsAppService(
		IRepository<CONDetails, long>  detailsRepository
              ,IDetailsManager detailsManager       

             )
            {
            _detailsRepository = detailsRepository;
             _detailsManager=detailsManager;


            }


            /// <summary>
                /// 获取的分页列表信息
                ///      </summary>
            /// <param name="input"></param>
            /// <returns></returns>
        //    [AbpAuthorize(DetailsPermissions.Pages_Details_Details_Query)]
            public async Task<PagedResultDto<DetailsListDto>> GetPaged(GetDetailssInput input)
		{

		    var query = _detailsRepository.GetAll()
                           
                            //模糊搜索Detailid
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Detailid.Contains(input.FilterText))                                                                                      
                            //模糊搜索Custid
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Custid.Contains(input.FilterText))                                                                                      
                            //模糊搜索SerialFrom
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.SerialFrom.Contains(input.FilterText))                                                                                      
                            //模糊搜索BuyerItem
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.BuyerItem.Contains(input.FilterText))                                                                                      
                            //模糊搜索Itemdesc
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Itemdesc.Contains(input.FilterText))                                                                                      
                            //模糊搜索Colorcode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Colorcode.Contains(input.FilterText))                                                                                      
                            //模糊搜索Size1
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Size1.Contains(input.FilterText))                                                                                      
                            //模糊搜索Pprfno
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Pprfno.Contains(input.FilterText))                                                           
			;
			// TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();

			var detailsList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

		  var detailsListDtos = ObjectMapper.Map<List<DetailsListDto>>(detailsList);

			return new PagedResultDto<DetailsListDto>(count,detailsListDtos);
		}


		/// <summary>
		/// 通过指定id获取DetailsListDto信息
		/// </summary>
	///	[AbpAuthorize(DetailsPermissions.Pages_Details_Details_Query)]
		public async Task<DetailsListDto> GetById(EntityDto<long> input)
		{
			var entity = await _detailsRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<DetailsListDto>(entity);
			return dto;
 		}


		/// <summary>
		/// 通过指定PPrfNo获取DetailsListDto信息
		/// </summary>
		public async Task<List<DetailsListDto>> GetBoxByPPrfNo(string PPrfNo)
		{
			var entityListDtos = new List<DetailsListDto>();
			if (PPrfNo.IsNullOrWhiteSpace()) { return null; }
			var query = _detailsRepository.GetAll().AsNoTracking()
			.WhereIf(!PPrfNo.IsNullOrWhiteSpace(), a => a.Pprfno.Equals(PPrfNo));

			var entityList = await query
				.OrderByDescending(a => a.SerialFrom)
				.ToListAsync();
			entityListDtos = ObjectMapper.Map<List<DetailsListDto>>(entityList);
			return entityListDtos;
		}



		/// <summary>
		/// 获取编辑 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//	[AbpAuthorize(DetailsPermissions.Pages_Details_Details_Create,DetailsPermissions.Pages_Details_Details_Edit)]
		public async Task<GetDetailsForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetDetailsForEditOutput();
DetailsEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _detailsRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<DetailsEditDto>(entity);
			}
			else
			{
				editDto = new DetailsEditDto();
			}
    


            output.Details = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
	//	[AbpAuthorize(DetailsPermissions.Pages_Details_Details_Create,DetailsPermissions.Pages_Details_Details_Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateDetailsInput input)
		{

			if (input.Details.Id.HasValue)
			{
				await Update(input.Details);
			}
			else
			{
				await Create(input.Details);
			}
		}


		/// <summary>
		/// 新增
		/// </summary>
		//[AbpAuthorize(DetailsPermissions.Pages_Details_Details_Create)]
		protected virtual async Task<DetailsEditDto> Create(DetailsEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<CONDetails>(input);
            //调用领域服务
            entity = await _detailsManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<DetailsEditDto>(entity);
            return dto;
		}

		/// <summary>
		/// 编辑
		/// </summary>
	//	[AbpAuthorize(DetailsPermissions.Pages_Details_Details_Edit)]
		protected virtual async Task Update(DetailsEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

		 var entity = await _detailsRepository.GetAsync(input.Id.Value);
          //  input.MapTo(entity);
          //将input属性的值赋值到entity中
             ObjectMapper.Map(input, entity);
            await _detailsManager.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
	//	[AbpAuthorize(DetailsPermissions.Pages_Details_Details_Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _detailsManager.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Details的方法
		/// </summary>
	//	[AbpAuthorize(DetailsPermissions.Pages_Details_Details_BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _detailsManager.BatchDelete(input);
		}




							//// custom codes



							//// custom codes end

    }
}


