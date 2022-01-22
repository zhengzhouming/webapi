
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
using WebAPI.Sabrina.MesWorkTagScan.Dtos;
using WebAPI.Sabrina.MesWorkTagScan.DomainService;

namespace WebAPI.Sabrina.MesWorkTagScan
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///
    ///</summary>
    /// [AbpAuthorize]
    public class MesWorkTagScanAppService : WebAPIAppServiceBase, IMesWorkTagScanAppService
    {
		private readonly IRepository<MesWorkTagScan, long>_mesWorkTagScanRepository;
		private readonly IMesWorkTagScanManager _mesWorkTagScanManager;
        /// <summary>
            /// 构造函数
            ///
			///</summary>
        public MesWorkTagScanAppService(IRepository<MesWorkTagScan, long>mesWorkTagScanRepository,IMesWorkTagScanManager mesWorkTagScanManager)
		{
			_mesWorkTagScanRepository = mesWorkTagScanRepository;
			_mesWorkTagScanManager=mesWorkTagScanManager;
		}


            /// <summary>
                /// 获取的分页列表信息
                ///
            ///</summary>
            /// <param name="input"></param>
            /// <returns></returns>
          ///  [AbpAuthorize(MesWorkTagScanPermissions.MesWorkTagScan_Query)]
            public async Task<PagedResultDto<MesWorkTagScanListDto>> GetPaged(GetMesWorkTagScansInput input){
			var query = _mesWorkTagScanRepository.GetAll()
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a =>a.tagInvoice.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagReceiptNumber.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagLocation.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagNumber.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagScanAccount.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagScanDateTime.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagUploadDateTime.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagScanPDASerial.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagScanPDAUUID.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagStyle.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagColor.Contains(input.FilterText))
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.tagSize.Contains(input.FilterText));
			
			var count = await query.CountAsync();
			var mesWorkTagScanList = await query
			.OrderBy(input.Sorting).AsNoTracking()
			.PageBy(input)
			.ToListAsync();
			var mesWorkTagScanListDtos = ObjectMapper.Map<List<MesWorkTagScanListDto>>(mesWorkTagScanList);
			return new PagedResultDto<MesWorkTagScanListDto>(count,mesWorkTagScanListDtos);
		}


		/// <summary>
		/// 通过指定id获取MesWorkTagScanListDto信息
		/// </summary>
		/// [AbpAuthorize(MesWorkTagScanPermissions.MesWorkTagScan_Query)]
		public async Task<MesWorkTagScanListDto> GetById(EntityDto<long> input)
		{
			var entity = await _mesWorkTagScanRepository.GetAsync(input.Id);
			var dto = ObjectMapper.Map<MesWorkTagScanListDto>(entity);
			return dto;
 		}

		/// <summary>
		/// 获取编辑 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		///[AbpAuthorize(MesWorkTagScanPermissions.MesWorkTagScan_Create,MesWorkTagScanPermissions.MesWorkTagScan_Edit)]
		public async Task<GetMesWorkTagScanForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetMesWorkTagScanForEditOutput();
			MesWorkTagScanEditDto editDto;
			if (input.Id.HasValue)
			{
				var entity = await _mesWorkTagScanRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<MesWorkTagScanEditDto>(entity);
			}
			else
			{
				editDto = new MesWorkTagScanEditDto();
			}
            output.MesWorkTagScan = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		///[AbpAuthorize(MesWorkTagScanPermissions.MesWorkTagScan_Create,MesWorkTagScanPermissions.MesWorkTagScan_Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateMesWorkTagScanInput input)
		{

			if (input.MesWorkTagScan.Id.HasValue)
			{
				await Update(input.MesWorkTagScan);
			}
			else
			{
				await Create(input.MesWorkTagScan);
			}
		}


		/// <summary>
		/// 新增
		/// </summary>
		///[AbpAuthorize(MesWorkTagScanPermissions.MesWorkTagScan_Create)]
		protected virtual async Task<MesWorkTagScanEditDto> Create(MesWorkTagScanEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<MesWorkTagScan>(input);
            //调用领域服务
            entity = await _mesWorkTagScanManager.CreateAsync(entity);
            var dto=ObjectMapper.Map<MesWorkTagScanEditDto>(entity);
            return dto;
		}

		/// <summary>
		/// 编辑
		/// </summary>
		///[AbpAuthorize(MesWorkTagScanPermissions.MesWorkTagScan_Edit)]
		protected virtual async Task Update(MesWorkTagScanEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

		 var entity = await _mesWorkTagScanRepository.GetAsync(input.Id.Value);
          //  input.MapTo(entity);
          //将input属性的值赋值到entity中
             ObjectMapper.Map(input, entity);
            await _mesWorkTagScanManager.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		///[AbpAuthorize(MesWorkTagScanPermissions.MesWorkTagScan_Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _mesWorkTagScanManager.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除MesWorkTagScan的方法
		/// </summary>
		///[AbpAuthorize(MesWorkTagScanPermissions.MesWorkTagScan_BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _mesWorkTagScanManager.BatchDelete(input);
		}

			// /api/services/app/MesWorkTagScan/GetByTagInvoice
		public async Task<List<MesWorkTagScanEditDto>> GetByTagInvoice(string tagInvoice)
		{

			if (tagInvoice is null || tagInvoice == "") { return null; }
			var entityListDtos = new List<MesWorkTagScanEditDto>();
			var query = _mesWorkTagScanRepository.GetAll().AsNoTracking()
				.WhereIf(!tagInvoice.IsNullOrWhiteSpace(), a => a.tagInvoice.Equals(tagInvoice));
			var entityList = await query.OrderBy(a => a.Id).ToListAsync();
			entityListDtos = ObjectMapper.Map<List<MesWorkTagScanEditDto>>(entityList);
			return entityListDtos;
		}

		// /api/services/app/MesWorkTagScan/GetByTagNumber
		public async Task<List<MesWorkTagScanEditDto>> GetByTagNumber(int InOrOut, int scanDeptID,  string tagNumber)
		{

			if (tagNumber is null || tagNumber == "") { return null; }
			var entityListDtos = new List<MesWorkTagScanEditDto>();
			var query = _mesWorkTagScanRepository.GetAll().AsNoTracking()
				.Where(a => a.isInOrOut.Equals(InOrOut))
				.Where(a => a.tagScanDeptID.Equals(scanDeptID))
				.WhereIf(!tagNumber.IsNullOrWhiteSpace(), a => a.tagNumber.Equals(tagNumber));
			var entityList = await query.OrderBy(a => a.Id).ToListAsync();
			entityListDtos = ObjectMapper.Map<List<MesWorkTagScanEditDto>>(entityList);
			return entityListDtos;
		}

		// /api/services/app/MesWorkTagScan/GetByTagLocation
		public async Task<List<MesWorkTagScanEditDto>> GetByTagLocation(string tagLocation, int deptId, int InOrOut)
		{

			if (tagLocation is null || tagLocation == "") { return null; }
			var entityListDtos = new List<MesWorkTagScanEditDto>();
			var query = _mesWorkTagScanRepository.GetAll().AsNoTracking()
				.Where(a => a.tagScanDeptID.Equals(deptId))
				.Where(a => a.isInOrOut.Equals(InOrOut))
				.Where(A =>A.isDels.Equals(0))
				.WhereIf(!tagLocation.IsNullOrWhiteSpace(), a => a.tagLocation.Equals(tagLocation));
			var entityList = await query.OrderBy(a => a.Id).ToListAsync();
			entityListDtos = ObjectMapper.Map<List<MesWorkTagScanEditDto>>(entityList);
			return entityListDtos;
		} 


		//// custom codes



		//// custom codes end

	}
}


