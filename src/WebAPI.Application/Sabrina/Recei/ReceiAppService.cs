
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
using WebAPI.Sabrina.Recei.Dtos;
using WebAPI.Sabrina.Recei.DomainService;

namespace WebAPI.Sabrina.Recei
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
   // [AbpAuthorize]
    public class ReceiAppService : WebAPIAppServiceBase, IReceiAppService
    {
         private readonly IRepository<Recei, long>        _receiRepository;



        private readonly IReceiManager _receiManager;
        /// <summary>
        /// 构造函数
        ///</summary>
        public ReceiAppService(
		IRepository<Recei, long>  receiRepository
              ,IReceiManager receiManager       

             )
            {
            _receiRepository = receiRepository;
             _receiManager=receiManager;


            }


            /// <summary>
                /// 获取的分页列表信息
                ///      </summary>
            /// <param name="input"></param>
            /// <returns></returns>
           // [AbpAuthorize(ReceiPermissions.Recei_Query)]
            public async Task<PagedResultDto<ReceiListDto>> GetPaged(GetReceisInput input)
		{

		    var query = _receiRepository.GetAll()
                           
                            //模糊搜索org
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.org.Contains(input.FilterText))                                                                                      
                            //模糊搜索subinv
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.subinv.Contains(input.FilterText))                                                                                      
                            //模糊搜索line
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.line.Contains(input.FilterText))                                                                                      
                            //模糊搜索style
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.style.Contains(input.FilterText))                                                                                      
                            //模糊搜索color
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.color.Contains(input.FilterText))                                                                                      
                            //模糊搜索size
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.size.Contains(input.FilterText))                                                                                      
                            //模糊搜索po
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.po.Contains(input.FilterText))                                                                                      
                            //模糊搜索boxCount
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.boxCount.Contains(input.FilterText))                                                                                      
                            //模糊搜索receiNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.receiNumber.Contains(input.FilterText))                                                                                      
                            //模糊搜索receiDate
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.receiDate.Contains(input.FilterText))                                                                                      
                            //模糊搜索receiEmp
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.receiEmp.Contains(input.FilterText))                                                                                      
                            //模糊搜索mark
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.mark.Contains(input.FilterText))                                                                                      
                            //模糊搜索receiInDate
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.receiInDate.Contains(input.FilterText))                                                                                      
                            //模糊搜索receiInPcName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.receiInPcName.Contains(input.FilterText))                                                           
			;
			// TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();

			var receiList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

		  var receiListDtos = ObjectMapper.Map<List<ReceiListDto>>(receiList);

			return new PagedResultDto<ReceiListDto>(count,receiListDtos);
		}


		/// <summary>
		/// 通过指定id获取ReceiListDto信息
		/// </summary>
		//[AbpAuthorize(ReceiPermissions.Recei_Query)]
		public async Task<ReceiListDto> GetById(EntityDto<long> input)
		{
			var entity = await _receiRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<ReceiListDto>(entity);
			return dto;
 		}

		/*
		 SELECT
				* 
			FROM
				receis 
			WHERE
				  org='TOP'
				and subinv = 'TA_HD' 
				AND line = 'CF36D' 
				AND style = 'BV5594' 
				AND color = '010' 
				AND size = 'L' 
				and (qtyCount > po or po is null)
				AND isFull = 0
		 */

		public async Task<List<ReceiListDto>> getOutCountQty(string org, string subinv, string line, string style, string color, string size)
		{
			/*
			var entityListDtos = new List<ReceiListDto>();
			if (org.IsNullOrWhiteSpace()) { return null; }
			if (subinv.IsNullOrWhiteSpace()) { return null; }
			if (line.IsNullOrWhiteSpace()) { return null; }
			if (style.IsNullOrWhiteSpace()) { return null; }
			if (color.IsNullOrWhiteSpace()) { return null; }
			if (size.IsNullOrWhiteSpace()) { return null; }

			var query = _receiRepository.GetAll().AsNoTracking()
			.WhereIf(!org.IsNullOrWhiteSpace(), a => a.org.Equals(org))
			.WhereIf(!subinv.IsNullOrWhiteSpace(), a => a.subinv.Equals(subinv))
			.WhereIf(!line.IsNullOrWhiteSpace(), a => a.line.Equals(line))
			.WhereIf(!style.IsNullOrWhiteSpace(), a => a.style.Equals(style))
			.WhereIf(!color.IsNullOrWhiteSpace(), a => a.line.Equals(color))
			.WhereIf(!size.IsNullOrWhiteSpace(), a => a.style.Equals(size)) 
			.WhereIf(!size.IsNullOrWhiteSpace(), a => a.isFull == 0); 



			var entityList = await query.OrderBy(a => a.Id).ToListAsync();
			entityListDtos = ObjectMapper.Map<List<ReceiListDto>>(entityList);
			return entityListDtos;
			*/

			var entityListDtos = new List<ReceiListDto>();
			var query = _receiRepository.GetAll().AsNoTracking()
				.WhereIf(!org.IsNullOrWhiteSpace(), a => a.org.Equals(org))
				.WhereIf(!subinv.IsNullOrWhiteSpace(), a => a.subinv.Equals(subinv))
				.WhereIf(!line.IsNullOrWhiteSpace(), a => a.line.Equals(line))
				.WhereIf(!style.IsNullOrWhiteSpace(), a => a.style.Equals(style))
				.WhereIf(!color.IsNullOrWhiteSpace(), a => a.color.Equals(color))
				.WhereIf(!size.IsNullOrWhiteSpace(), a => a.size.Equals(size))				
				.Where(a => a.isFull == 0)
				;
			var entityList = await query.OrderBy(a => a.Id).ToListAsync();			 
			entityListDtos = ObjectMapper.Map<List<ReceiListDto>>(entityList);
			return entityListDtos;
		}



		/// <summary>
		/// 获取编辑 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ReceiPermissions.Recei_Create,ReceiPermissions.Recei_Edit)]
		public async Task<GetReceiForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetReceiForEditOutput();
ReceiEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _receiRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<ReceiEditDto>(entity);
			}
			else
			{
				editDto = new ReceiEditDto();
			}
    


            output.Recei = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ReceiPermissions.Recei_Create,ReceiPermissions.Recei_Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateReceiInput input)
		{

			if (input.Recei.Id.HasValue)
			{
				await Update(input.Recei);
			}
			else
			{
				await Create(input.Recei);
			}
		}


		/// <summary>
		/// 新增
		/// </summary>
		//[AbpAuthorize(ReceiPermissions.Recei_Create)]
		protected virtual async Task<ReceiEditDto> Create(ReceiEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<Recei>(input);
            //调用领域服务
            entity = await _receiManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<ReceiEditDto>(entity);
            return dto;
		}

		/// <summary>
		/// 编辑
		/// </summary>
		//[AbpAuthorize(ReceiPermissions.Recei_Edit)]
		protected virtual async Task Update(ReceiEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

		 var entity = await _receiRepository.GetAsync(input.Id.Value);
          //  input.MapTo(entity);
          //将input属性的值赋值到entity中
             ObjectMapper.Map(input, entity);
            await _receiManager.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ReceiPermissions.Recei_Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _receiManager.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Recei的方法
		/// </summary>
		//[AbpAuthorize(ReceiPermissions.Recei_BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _receiManager.BatchDelete(input);
		}




							//// custom codes



							//// custom codes end

    }
}


