
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using WebAPI.Sabrina.Invrecei.Dtos;
using WebAPI.Sabrina.Invrecei.DomainService;

namespace WebAPI.Sabrina.Invrecei
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
   // [AbpAuthorize]
    public class InvreceiAppService : WebAPIAppServiceBase, IInvreceiAppService
    {
         private readonly IRepository<Invrecei, long>        _invreceiRepository;



        private readonly IInvreceiManager _invreceiManager;
        /// <summary>
        /// 构造函数
        ///</summary>
        public InvreceiAppService(
		IRepository<Invrecei, long>  invreceiRepository
              ,IInvreceiManager invreceiManager       

             )
            {
            _invreceiRepository = invreceiRepository;
             _invreceiManager=invreceiManager;


            }


            /// <summary>
                /// 获取的分页列表信息
                ///      </summary>
            /// <param name="input"></param>
            /// <returns></returns>
         //   [AbpAuthorize(InvreceiPermissions.Invrecei_Query)]
            public async Task<PagedResultDto<InvreceiListDto>> GetPaged(GetInvreceisInput input)
		{

		    var query = _invreceiRepository.GetAll()
                           
                            //模糊搜索org
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.org.Contains(input.FilterText))                                                                                      
                            //模糊搜索subinv
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.subinv.Contains(input.FilterText))                                                                                      
                            //模糊搜索line
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.line.Contains(input.FilterText))                                                                                      
                            //模糊搜索TagNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.TagNumber.Contains(input.FilterText))                                                                                      
                            //模糊搜索kg
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.kg.Contains(input.FilterText))                                                                                      
                            //模糊搜索scantime
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.scantime.Contains(input.FilterText))                                                                                      
                            //模糊搜索update_date
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.update_date.Contains(input.FilterText))                                                                                      
                            //模糊搜索create_pc
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.create_pc.Contains(input.FilterText))                                                                                      
                            //模糊搜索exeStatus
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.exeStatus.Contains(input.FilterText))                                                           
			;
			// TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();

			var invreceiList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

		  var invreceiListDtos = ObjectMapper.Map<List<InvreceiListDto>>(invreceiList);

			return new PagedResultDto<InvreceiListDto>(count,invreceiListDtos);
		}


		/// <summary>
		/// 通过指定id获取InvreceiListDto信息
		/// </summary>
		//[AbpAuthorize(InvreceiPermissions.Invrecei_Query)]
		public async Task<InvreceiListDto> GetById(EntityDto<long> input)
		{
			var entity = await _invreceiRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<InvreceiListDto>(entity);
			return dto;
 		} 

		/// <summary>
		/// 通过指定条码号获取InvreceiListDto信息
		/// </summary>
		//[AbpAuthorize(InvreceiPermissions.Invrecei_Query)]
		public async Task<List<InvreceiListDto>> GetTagNumber(string tagNumber)
		{
			var entityListDtos = new List<InvreceiListDto>();
			if (tagNumber.IsNullOrWhiteSpace()) { return null; }
			 
			var query = _invreceiRepository.GetAll().AsNoTracking()
			.WhereIf(!tagNumber.IsNullOrWhiteSpace(), a => a.TagNumber.Equals(tagNumber));

			var entityList = await query
				.OrderByDescending(a => a.scantime)
				.ToListAsync();
			entityListDtos = ObjectMapper.Map<List<InvreceiListDto>>(entityList);
			return entityListDtos;

			 
		}

		/// <summary>
		/// 获取编辑 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(InvreceiPermissions.Invrecei_Create,InvreceiPermissions.Invrecei_Edit)]
		public async Task<GetInvreceiForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetInvreceiForEditOutput();
InvreceiEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _invreceiRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<InvreceiEditDto>(entity);
			}
			else
			{
				editDto = new InvreceiEditDto();
			}
    


            output.Invrecei = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(InvreceiPermissions.Invrecei_Create,InvreceiPermissions.Invrecei_Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateInvreceiInput input)
		{

			if (input.Invrecei.Id.HasValue)
			{
				await Update(input.Invrecei);
			}
			else
			{
				await Create(input.Invrecei);
			}
		}


		/// <summary>
		/// 新增
		/// </summary>
		//[AbpAuthorize(InvreceiPermissions.Invrecei_Create)]
		protected virtual async Task<InvreceiEditDto> Create(InvreceiEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<Invrecei>(input);
            //调用领域服务
            entity = await _invreceiManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<InvreceiEditDto>(entity);
            return dto;
		}

		/// <summary>
		/// 编辑
		/// </summary>
		//[AbpAuthorize(InvreceiPermissions.Invrecei_Edit)]
		protected virtual async Task Update(InvreceiEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

		 var entity = await _invreceiRepository.GetAsync(input.Id.Value);
          //  input.MapTo(entity);
          //将input属性的值赋值到entity中
             ObjectMapper.Map(input, entity);
            await _invreceiManager.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(InvreceiPermissions.Invrecei_Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _invreceiManager.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Invrecei的方法
		/// </summary>
		//[AbpAuthorize(InvreceiPermissions.Invrecei_BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _invreceiManager.BatchDelete(input);
		}




							//// custom codes



							//// custom codes end

    }
}


