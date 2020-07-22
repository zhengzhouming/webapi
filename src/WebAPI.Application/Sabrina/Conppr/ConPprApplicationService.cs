
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
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using WebAPI.Sabrina.Conppr;
using WebAPI.Sabrina.Conppr.Dtos;
using WebAPI.Sabrina.Conppr.DomainService;
using WebAPI.Sabrina.Conppr.Authorization;
using Masuit.Tools.Mapping.Extensions;
using Abp.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;
using WebAPI.Sabrina.Details.DomainService;
using WebAPI.Sabrina.Details;
using WebAPI.Sabrina.barcodeScan;
using WebAPI.Sabrina.barcodeScan.DomainService;
using WebAPI.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;
using NPOI.SS.Formula.Functions;
using Microsoft.AspNetCore.Mvc.Rendering;
using L._52ABP.Common.Extensions;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace WebAPI.Sabrina.Conppr
{
    /// <summary>
    /// ConPpr应用层服务的接口实现方法  
    ///</summary>
    //[AbpAuthorize]
    public class ConPprAppService : WebAPIAppServiceBase, IConPprAppService
	{
        private readonly IRepository<ConPpr, long> _entityRepository;
        private readonly IConPprManager _entityManager;
		private readonly IRepository<Inv, long> _invRepository;
		private readonly IRepository<CONDetails, long> _detailsRepository; 

		/// <summary>
		/// 构造函数 
		///</summary>
		public ConPprAppService(
        IRepository<ConPpr, long> entityRepository,
        IConPprManager entityManager,
		IRepository<Inv,long> invRepository,
		IRepository<CONDetails, long> detailsRepository
		)
        {
            _entityRepository = entityRepository; 
            _entityManager=entityManager;
			_invRepository = invRepository;
			_detailsRepository = detailsRepository;
		}


		/// <summary>
		/// 获取ConPpr的分页列表信息
		///</summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ConPprPermissions.Query)] 
		public async Task<PagedResultDto<ConPprListDto>> GetPaged(GetConPprsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ConPprListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<ConPprListDto>>();

			return new PagedResultDto<ConPprListDto>(count,entityListDtos);
		}

		/// <summary>
		/// 根据 cust_id and  Serial_From 获取本箱信息
		/// </summary>
		/// <param name="serial_From"> 箱号 </param>
		/// <param name="cust_id"> 客户 </param>
		/// <returns></returns>
		public async Task<List<ConPprListDto>> GetBoxBySerial_From(string serial_From, string cust_id )
		{

			var entityListDtos = new List<ConPprListDto>();
			if (serial_From.IsNullOrWhiteSpace()) { return null; }
			if (cust_id.IsNullOrWhiteSpace()) { return null; }
			var query = _entityRepository.GetAll().AsNoTracking()
			.WhereIf(!serial_From.IsNullOrWhiteSpace(), a => a.Serial_From.Equals(serial_From))
			.WhereIf(!cust_id.IsNullOrWhiteSpace(), a => a.Cust_id.Equals(cust_id));

			var entityList = await query.OrderBy(a => a.Id).ToListAsync();
			entityListDtos = ObjectMapper.Map<List<ConPprListDto>>(entityList);
			return entityListDtos; 

			
		}


		public async Task<List<ConPprListDto>> GetBoxByPPrfNo(string PPrfNo)
		{

			var entityListDtos = new List<ConPprListDto>();
			if (PPrfNo.IsNullOrWhiteSpace()) { return null; } 
			var query = _entityRepository.GetAll().AsNoTracking()
			.WhereIf(!PPrfNo.IsNullOrWhiteSpace(), a => a.PPrfNo.Equals(PPrfNo));
			var entityList = await query
				.OrderByDescending(a => a.Con_no)
				//.OrderBy(a => a.Con_no)

					//.OrderBy(input.Sorting).AsNoTracking()			
					//.PageBy(input)
					.ToListAsync();

			entityListDtos = ObjectMapper.Map<List<ConPprListDto>>(entityList);
			return entityListDtos; 
		}


		/// <summary>
		/// 通过指定id获取ConPprListDto信息
		/// </summary>
		//[AbpAuthorize(ConPprPermissions.Query)] 
		public async Task<ConPprListDto> GetById(EntityDto<long> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<ConPprListDto>();
		}

		/// <summary>
		/// 获取编辑 ConPpr
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ConPprPermissions.Create,ConPprPermissions.Edit)]
		public async Task<GetConPprForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetConPprForEditOutput();
ConPprEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<ConPprEditDto>();

				//conPprEditDto = ObjectMapper.Map<List<conPprEditDto>>(entity);
			}
			else
			{
				editDto = new ConPprEditDto();
			}

			output.ConPpr = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改ConPpr的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ConPprPermissions.Create,ConPprPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateConPprInput input)
		{

			if (input.ConPpr.Id.HasValue)
			{
				await Update(input.ConPpr);
			}
			else
			{
				await Create(input.ConPpr);
			}
		}


		/// <summary>
		/// 新增ConPpr
		/// </summary>
		//[AbpAuthorize(ConPprPermissions.Create)]
		protected virtual async Task<ConPprEditDto> Create(ConPprEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <ConPpr>(input);
            var entity=input.MapTo<ConPpr>();			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<ConPprEditDto>();
		}

		/// <summary>
		/// 编辑ConPpr
		/// </summary>
		//[AbpAuthorize(ConPprPermissions.Edit)]
		protected virtual async Task Update(ConPprEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);
			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除ConPpr信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ConPprPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除ConPpr的方法
		/// </summary>
		//[AbpAuthorize(ConPprPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}




		

		// 多表查询出订单信息
		public List<OrderInfos> getOrderByTagNumber(string tagNumber )
		{

			/*
			        private readonly IRepository<ConPpr, long> _entityRepository;					
					private readonly IRepository<Inv, long> _invRepository;
					private readonly IRepository<CONDetails, long> _detailsRepository; 

					SELECT
					cp.PO,
					cp.MAIN_LINE,
					d.custid,
					d.BuyerItem,
					d.itemdesc,
					d.Colorcode,
					cp.Serial_From,
					cp.qty,
					cp.con_no 
				FROM
					conpprs cp
					LEFT JOIN (
					SELECT
						c.PPrfNo,
						i.tagnumber 
					FROM
						conpprs c
						LEFT JOIN ( SELECT DISTINCT con_no, tagnumber FROM inv WHERE TagNumber = '00006285770106689409' ) i ON c.Serial_From = i.con_no 
					WHERE
						i.TagNumber = '00006285770106689409' 
					) c ON c.PPrfNo = cp.PPrfNo
					LEFT JOIN ( SELECT DISTINCT SerialFrom, custid, BuyerItem, itemdesc, Colorcode, Pprfno FROM detailss ) d ON cp.PPrfNo = d.Pprfno 
					AND cp.Serial_From = d.SerialFrom 
				WHERE
					c.tagnumber = '00006285770106689409'

			 */

			// -----------------查出这个TAG的箱号---------------------
			var query = from inv in _invRepository.GetAll()
						.Where(a => a.TagNumber.Equals(tagNumber))
						.DistinctBy(a => a.Con_no)

			// ---------------以箱号查出这个PO的pprfno-----------------------	
						join conppr in _entityRepository.GetAll()						
						on inv.Con_no equals conppr.Serial_From						 
						into cls_conppr
						from g_conppr in cls_conppr.DefaultIfEmpty()

			// ---------------以pprfno查出这个PO的所有箱数量-----------------------
						join conpprs in _entityRepository.GetAll()						 
						on g_conppr.PPrfNo equals conpprs.PPrfNo
						into cls_conpprs
						from g_conpprs in cls_conpprs.DefaultIfEmpty()
						
			// ---------------以pprfno查出这个PO的订单信息-----------------------
						join details in _detailsRepository.GetAll()
						.DistinctBy(a => a.SerialFrom)
						// on new { m.ID, Phone = m.Phone1 } equals new { q.ID, Phone = q.Phone2 }
						on   new  { PPrfNo = g_conpprs.PPrfNo , Serial_From =  g_conpprs.Serial_From } equals new  { PPrfNo = details.Pprfno  , Serial_From = details.SerialFrom }
						into cls_pprinfo
						from g_details in cls_pprinfo.DefaultIfEmpty()
						select new OrderInfos
						{
							PPrfNo = g_conpprs.PPrfNo,
							po = g_conpprs.PPrfNo,
							MAIN_LINE = g_conpprs.MAIN_LINE,
							custid = g_conpprs.Cust_id,							
							BuyerItem = g_details.BuyerItem,
							itemdesc = g_details.Itemdesc,
							Colorcode = g_details.Colorcode,
							Serial_From = g_conpprs.Serial_From,
							conNo = g_conpprs.Con_no,
							qty = g_conpprs.Qty								
						};
			List<OrderInfos> list =   query.ToList() ;
			return list;
		} 

		public class OrderInfos
		{			 
			public string po { get; set; }
			public string MAIN_LINE { get; set; }
			public string custid { get; set; }
			public string BuyerItem { get; set; }
			public string itemdesc { get; set; }
			public string Colorcode { get; set; }
			public string Serial_From { get; set; }
			 public int? conNo { get; set; }
			public int? qty { get; set; }
			public string PPrfNo { get; set; }


		}



		// 多表查询出库存信息
		public List<StockInfos> getStockByTagNumber(string tagNumber)
		{

			/*
			        private readonly IRepository<ConPpr, long> _entityRepository;					
					private readonly IRepository<Inv, long> _invRepository;
					private readonly IRepository<CONDetails, long> _detailsRepository; 
			-- 1、查出箱号
			-- 2、查出箱的PPrfNo
			-- 3、查出PPrfNo下的所有箱号
			-- 4、查出所有箱下的所有最后扫描时间
			-- 5、查出所有箱下的所有最后扫描时间的ID  也就是箱的最后位置ID
			-- 6、查出所有最后一箱的库存相关信息
				------------------------------------------------

			-- 6、查出所有最后一箱的库存相关信息
				SELECT
					i.Cust_id,
					c.PPrfNo,
					c.con_no AS BoxNo,
					i.subinv,
					i.location,
					i.con_no AS SerialFrom,
					d.Size1,
					d.qty,
					i.ScanTime 
				FROM
					inv i
					LEFT JOIN conpprs c ON c.Serial_From = i.con_no
					LEFT JOIN detailss d ON d.PPrfNo = c.PPrfNo 
					AND d.SerialFrom = i.con_no 
				WHERE
					i.id IN (

			-- 5、查出所有箱下的所有最后扫描时间的ID  也就是箱的最后位置ID
					SELECT
						id   
					FROM
						inv i 
					WHERE
						scantime IN (

						-- 4、查出所有箱下的所有最后扫描时间 并只要本PPR下的箱号的ID
						SELECT
							max( scantime ) 
						FROM
							inv 
						WHERE
							Con_no IN (

						-- 3、查出PPrfNo下的所有箱号
							SELECT
								Serial_From 
							FROM
								conpprs cps
								LEFT JOIN (

						-- 2、查出箱的PPrfNo
								SELECT
									cp.PPrfNo,
									i.TagNumber 
								FROM
									conpprs cp

						-- 1、查出箱号
									LEFT JOIN ( SELECT DISTINCT con_no, TagNumber FROM inv WHERE TagNumber = '00006285770106689447' ) i ON i.con_no = cp.Serial_From 
								WHERE
									i.TagNumber = '00006285770106689447' 
								) cp ON cp.PPrfNo = cps.PPrfNo 
							WHERE
								cp.TagNumber = '00006285770106689447' 
							) 
						GROUP BY
							con_no 
						) 
						AND con_no IN (   -- 4、  并只要本PPR下的箱号的ID
						SELECT
							Serial_From 
						FROM
							conpprs cps
							LEFT JOIN (
							SELECT
								cp.PPrfNo,
								i.TagNumber 
							FROM
								conpprs cp
								LEFT JOIN ( SELECT DISTINCT con_no, TagNumber FROM inv WHERE TagNumber = '00006285770106689447' ) i ON i.con_no = cp.Serial_From 
							WHERE
								i.TagNumber = '00006285770106689447' 
							) cp ON cp.PPrfNo = cps.PPrfNo 
						WHERE
							cp.TagNumber = '00006285770106689447' 
						) 
					) 
					AND i.subinv = 'S010' 
				GROUP BY
					i.Cust_id,
					c.PPrfNo,
					c.con_no,
					i.subinv,
					i.location,
					i.con_no,
					d.Size1,
					d.qty,
					i.ScanTime 
				ORDER BY
					c.con_no,
					i.ScanTime,
					d.Size1,
					d.Qty
			 */



			// -----------------1、查出这个TAG的箱号---------------------
			var query = from inv in _invRepository.GetAll()
						.Where(a => a.TagNumber.Equals(tagNumber))
						.DistinctBy(a => a.Con_no)
						.Select(a => a.Con_no)

							// ---------------2、以箱号查出这个PO的pprfno-----------------------	
						join conppr in _entityRepository.GetAll()
						on inv equals conppr.Serial_From
						into cls_conppr


						// ---------------3、以pprfno查出这个PO的所有箱箱号-----------------------
						from g_conppr in cls_conppr.DefaultIfEmpty()
						join conpprs in _entityRepository.GetAll()
						on g_conppr.PPrfNo equals conpprs.PPrfNo
						into cls_conpprs
						//from g_conpprs in cls_conpprs.DefaultIfEmpty()

						// ---------------4、查出所有箱下的所有最后扫描时间-----------------------	
						from g_conpprs in cls_conpprs.DefaultIfEmpty( )
						join con_inv in _invRepository.GetAll()
						on g_conpprs.Serial_From equals con_inv.Con_no
						into cls_con_invs
						 
						 

			// ---------------5、查出所有箱下的所有最后扫描时间的ID  也就是箱的最后位置ID-----------------------	
						from g_con_invs in cls_con_invs.DefaultIfEmpty()
						 .OrderByDescending(a=> a.Scantime).Take(1)
						
						join time_inv in _invRepository.GetAll() 
						on new { Scantime = g_con_invs.Scantime, Serial_From = g_con_invs.Con_no } equals new { Scantime = time_inv.Scantime, Serial_From = time_inv.Con_no }
						into cls_timeID_inv
						
					// ---------------- 6、查出所有最后一箱的库存相关信息 -----------------------	
						from g_timeID_inv in cls_timeID_inv.DefaultIfEmpty()
						join details in _detailsRepository.GetAll()
						on new { pprfno = g_conpprs.PPrfNo, SerialFrom = g_timeID_inv.Con_no } equals new  { pprfno = details.Pprfno, SerialFrom = details.SerialFrom }
						into cls_details
						
							from g_details in cls_details.DefaultIfEmpty()
						
						select new StockInfos
						{
						 
						   custid = g_conpprs.Cust_id,
						   PPrfNo = g_conpprs.PPrfNo,
						   conNo = g_conpprs.Con_no,
						   Subinv = g_timeID_inv.Subinv,
						   Location = g_timeID_inv.Location,
						   Serial_From = g_conpprs.Serial_From,
						   Size1 = g_details.Size1,
						   qty = g_details.Qty,
						   ScanTime = g_timeID_inv.Scantime,	
						   i_id = g_timeID_inv.Id

						};
			List<StockInfos> list = query.ToList();
			return list;
		}

		public class StockInfos
		{
			public long? i_id { get; set; }
			public string custid { get; set; }
			public string PPrfNo { get; set; }
			public int? conNo { get; set; }
			public string Subinv { get; set; }
			public string Location { get; set; }
			public string Serial_From { get; set; }
			public string Size1 { get; set; }
			public int? qty { get; set; }			
			public DateTime? ScanTime { get; set; }
			
		}
	}
}


