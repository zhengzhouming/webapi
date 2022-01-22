
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
using WebAPI.Sabrina.MesWorkTagScanReceipt.Dtos;
using WebAPI.Sabrina.MesWorkTagScanReceipt.DomainService;

namespace WebAPI.Sabrina.MesWorkTagScanReceipt
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///
	///<summary>
    //[AbpAuthorize]
    public class MesWorkTagScanReceiptAppService : WebAPIAppServiceBase, IMesWorkTagScanReceiptAppService
    {
		private readonly IRepository<MesWorkTagScanReceipt, long>
        _mesWorkTagScanReceiptRepository;
		private readonly IMesWorkTagScanReceiptManager _mesWorkTagScanReceiptManager;
			/// <summary>
            /// 构造函数
            ///
			///<summary>
        public MesWorkTagScanReceiptAppService(IRepository<MesWorkTagScanReceipt, long>mesWorkTagScanReceiptRepository,IMesWorkTagScanReceiptManager mesWorkTagScanReceiptManager)
		{
            _mesWorkTagScanReceiptRepository = mesWorkTagScanReceiptRepository;
            _mesWorkTagScanReceiptManager=mesWorkTagScanReceiptManager;
            }
            /// <summary>
            /// 获取的分页列表信息
            ///
            ///<summary>
            /// <param name="input"></param>
            /// <returns></returns>
            ///[AbpAuthorize(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Query)]
            public async Task<PagedResultDto<MesWorkTagScanReceiptListDto>> GetPaged(GetMesWorkTagScanReceiptsInput input)
		{
			var query = _mesWorkTagScanReceiptRepository.GetAll()
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a =>a.Version.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagScanAccount.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagScanDateTime.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagScanPDASerial.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagScanPDAUUID.Contains(input.FilterText));

				// TODO:根据传入的参数添加过滤条件
				var count = await query.CountAsync();
				var mesWorkTagScanReceiptList = await query
				.OrderBy(input.Sorting).AsNoTracking()
				.PageBy(input)
				.ToListAsync();
			
			var mesWorkTagScanReceiptListDtos = ObjectMapper.Map<List<MesWorkTagScanReceiptListDto>>(mesWorkTagScanReceiptList);
			return new PagedResultDto<MesWorkTagScanReceiptListDto>(count,mesWorkTagScanReceiptListDtos);
		}


		/// <summary>
		/// 通过指定id获取MesWorkTagScanReceiptListDto信息
		/// </summary>
		///[AbpAuthorize(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Query)]
		public async Task<MesWorkTagScanReceiptListDto> GetById(EntityDto<long> input)
		{
			var entity = await _mesWorkTagScanReceiptRepository.GetAsync(input.Id);
			var dto = ObjectMapper.Map<MesWorkTagScanReceiptListDto>(entity);
			return dto;
 		}

		/// <summary>
		/// 获取编辑 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		///[AbpAuthorize(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Create,MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Edit)]
		public async Task<GetMesWorkTagScanReceiptForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetMesWorkTagScanReceiptForEditOutput();
			MesWorkTagScanReceiptEditDto editDto;
			if (input.Id.HasValue)
			{
				var entity = await _mesWorkTagScanReceiptRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<MesWorkTagScanReceiptEditDto>(entity);
			}
			else
			{
				editDto = new MesWorkTagScanReceiptEditDto();
			}
            output.MesWorkTagScanReceipt = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		///[AbpAuthorize(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Create,MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateMesWorkTagScanReceiptInput input)
		{

			if (input.MesWorkTagScanReceipt.Id.HasValue)
			{
				await Update(input.MesWorkTagScanReceipt);
			}
			else
			{
				await Create(input.MesWorkTagScanReceipt);
			}
		}


		/// <summary>
		/// 新增
		/// </summary>
		///[AbpAuthorize(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Create)]
		protected virtual async Task<MesWorkTagScanReceiptEditDto> Create(MesWorkTagScanReceiptEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<MesWorkTagScanReceipt>(input);
            //调用领域服务
            entity = await _mesWorkTagScanReceiptManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<MesWorkTagScanReceiptEditDto>(entity);
            return dto;
		}

		/// <summary>
		/// 编辑
		/// </summary>
		///[AbpAuthorize(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Edit)]
		protected virtual async Task Update(MesWorkTagScanReceiptEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

		 var entity = await _mesWorkTagScanReceiptRepository.GetAsync(input.Id.Value);
          //  input.MapTo(entity);
          //将input属性的值赋值到entity中
             ObjectMapper.Map(input, entity);
            await _mesWorkTagScanReceiptManager.UpdateAsync(entity);
		}

		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		///[AbpAuthorize(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _mesWorkTagScanReceiptManager.DeleteAsync(input.Id);
		}

		/// <summary>
		/// 批量删除MesWorkTagScanReceipt的方法
		/// </summary>
		///[AbpAuthorize(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _mesWorkTagScanReceiptManager.BatchDelete(input);
		}


		/// <summary>
		/// 最大ID的批号  
		///
		///<summary>
		/// <param name="input"></param>
		/// <returns></returns>
		///[AbpAuthorize(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Query)]
		public async Task<PagedResultDto<MesWorkTagScanReceiptListDto>> GetMaxVersion()
		{
			var query = _mesWorkTagScanReceiptRepository.GetAll();

			// TODO:根据传入的参数添加过滤条件
			var count = await query.CountAsync();
			var mesWorkTagScanReceiptList = await query			
			.OrderByDescending(a=> a.Id ).Take(1).AsNoTracking()
			.OrderByDescending(a => a.Version).Take(1).AsNoTracking()
			.ToListAsync();

			var mesWorkTagScanReceiptListDtos = ObjectMapper.Map<List<MesWorkTagScanReceiptListDto>>(mesWorkTagScanReceiptList);
			return new PagedResultDto<MesWorkTagScanReceiptListDto>(count, mesWorkTagScanReceiptListDtos);
		}
	}
}


