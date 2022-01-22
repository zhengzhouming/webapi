
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
using WebAPI.Sabrina.MesDept.Dtos;
using WebAPI.Sabrina.MesDept.DomainService;

namespace WebAPI.Sabrina.MesDept
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///
    ///</summary>
    // [AbpAuthorize]
    public class MesDeptAppService : WebAPIAppServiceBase, IMesDeptAppService
    {
    private readonly IRepository<MesDept, long>
        _MesDeptRepository;



        private readonly IMesDeptManager _MesDeptManager;
        /// <summary>
            /// 构造函数
            ///
       // </summary>
        public MesDeptAppService(
        IRepository<MesDept, long>
MesDeptRepository
            ,IMesDeptManager MesDeptManager

            )
            {
            _MesDeptRepository = MesDeptRepository;
             _MesDeptManager=MesDeptManager;


            }


            /// <summary>
                /// 获取的分页列表信息
                ///
          ///  </summary>
            /// <param name="input"></param>
            /// <returns></returns>
          //  [AbpAuthorize(MesDeptPermissions.MesDept_Query)]
            public async Task<PagedResultDto<MesDeptListDto>> GetPaged(GetMesDeptsInput input)
    {

		var query = _MesDeptRepository.GetAll()
		.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a =>a.DeptName.Contains(input.FilterText))
		.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.DeptNumber.Contains(input.FilterText))
		.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Marsk.Contains(input.FilterText));
    // TODO:根据传入的参数添加过滤条件

    var count = await query.CountAsync();

    var MesDeptList = await query
    .OrderBy(input.Sorting).AsNoTracking()
    .PageBy(input)
    .ToListAsync();

    var MesDeptListDtos = ObjectMapper.Map<List<MesDeptListDto>>(MesDeptList);

			return new PagedResultDto<MesDeptListDto>(count,MesDeptListDtos);
		}


		/// <summary>
		/// 通过指定id获取MesDeptListDto信息
		/// </summary>
		///[AbpAuthorize(MesDeptPermissions.MesDept_Query)]
		public async Task<MesDeptListDto> GetById(EntityDto<long> input)
		{
			var entity = await _MesDeptRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<MesDeptListDto>(entity);
			return dto;
 		}

		/// <summary>
		/// 获取编辑 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		///[AbpAuthorize(MesDeptPermissions.MesDept_Create,MesDeptPermissions.MesDept_Edit)]
		public async Task<GetMesDeptForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetMesDeptForEditOutput();
MesDeptEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _MesDeptRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<MesDeptEditDto>(entity);
			}
			else
			{
				editDto = new MesDeptEditDto();
			}



            output.MesDept = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		///[AbpAuthorize(MesDeptPermissions.MesDept_Create,MesDeptPermissions.MesDept_Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateMesDeptInput input)
		{

			if (input.MesDept.Id.HasValue)
			{
				await Update(input.MesDept);
			}
			else
			{
				await Create(input.MesDept);
			}
		}


		/// <summary>
		/// 新增
		/// </summary>
		///[AbpAuthorize(MesDeptPermissions.MesDept_Create)]
		protected virtual async Task<MesDeptEditDto> Create(MesDeptEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<MesDept>(input);
            //调用领域服务
            entity = await _MesDeptManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<MesDeptEditDto>(entity);
            return dto;
		}

		/// <summary>
		/// 编辑
		/// </summary>
		///[AbpAuthorize(MesDeptPermissions.MesDept_Edit)]
		protected virtual async Task Update(MesDeptEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

		 var entity = await _MesDeptRepository.GetAsync(input.Id.Value);
          //  input.MapTo(entity);
          //将input属性的值赋值到entity中
             ObjectMapper.Map(input, entity);
            await _MesDeptManager.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		///[AbpAuthorize(MesDeptPermissions.MesDept_Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _MesDeptManager.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除MesDept的方法
		/// </summary>
		///[AbpAuthorize(MesDeptPermissions.MesDept_BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _MesDeptManager.BatchDelete(input);
		}

		//public async Task<List<ReceiListDto>> getOutCountQty(string org, string subinv, string line, string style, string color, string size)
		public async Task<List<MesDeptListDto>> GetByDeptID(string deptID)
		{
			 
			if(deptID is null || deptID == "") { return null; }
			var entityListDtos = new List<MesDeptListDto>();
			var query = _MesDeptRepository.GetAll().AsNoTracking()
				.WhereIf(!deptID.IsNullOrWhiteSpace(), a => a.DeptNumber.Equals(deptID));
			var entityList = await query.OrderBy(a => a.Id).ToListAsync();
			entityListDtos = ObjectMapper.Map<List<MesDeptListDto>>(entityList);
			return entityListDtos;
		}

	}
}


