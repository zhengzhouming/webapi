
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

		/// <summary>
		/// 构造函数 
		///</summary>
		public ConPprAppService(
        IRepository<ConPpr, long> entityRepository
        ,IConPprManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
			 
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

			//////////////////////
			/*
			var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ConPprListDto>>(entityList);
			var entityListDtos = entityList.MapTo<List<ConPprListDto>>();

			return new PagedResultDto<ConPprListDto>(count, entityListDtos);
			*/
			/*
			  public async Task<List<LoginListDto>> GetByLoginName(string username, string pwd)
        {

            var entityListDtos = new List<LoginListDto>();
            if (username.IsNullOrWhiteSpace()) { return null; }
            if (pwd.IsNullOrWhiteSpace()) { return null; }
            var query = _entityRepository.GetAll().AsNoTracking()
            .WhereIf(!username.IsNullOrWhiteSpace(), a => a.LoginName.Equals(username) )
            .WhereIf(!pwd.IsNullOrWhiteSpace(), a => a.LoginPwd.Equals(pwd));

            var entityList = await query.OrderBy(a => a.LoginLine).ToListAsync();
            entityListDtos = ObjectMapper.Map<List<LoginListDto>>(entityList);
            return entityListDtos; ;

        }
			 */
		}


		public async Task<List<ConPprListDto>> GetBoxByPPrfNo(string PPrfNo)
		{

			var entityListDtos = new List<ConPprListDto>();
			if (PPrfNo.IsNullOrWhiteSpace()) { return null; } 
			var query = _entityRepository.GetAll().AsNoTracking()
			.WhereIf(!PPrfNo.IsNullOrWhiteSpace(), a => a.PPrfNo.Equals(PPrfNo));

			//var entityList = await query.OrderBy(a => a.Id).ToListAsync();


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


		/// <summary>
		/// 导出ConPpr为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}


		// async Task<int> GetPprByTagNumber(params object[] parameters)
		public async Task<List<T>> SqlQuery<T>(string sql) where T : class, new()
		{
			// XMAPIDbContext

			//	var entity = await _entityRepository.GetAsync(id);
			string sqlstr = @"
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
									LEFT JOIN ( SELECT DISTINCT con_no, tagnumber FROM inv WHERE TagNumber = '00047112100082682473' ) i ON c.Serial_From = i.con_no 
								WHERE
									i.TagNumber = '00047112100082682473' 
								) c ON c.PPrfNo = cp.PPrfNo
								LEFT JOIN ( SELECT DISTINCT SerialFrom, custid, BuyerItem, itemdesc, Colorcode, Pprfno FROM detailss ) d ON cp.PPrfNo = d.Pprfno 
								AND cp.Serial_From = d.SerialFrom 
							WHERE
								c.tagnumber = '00047112100082682473'";
			sql = sqlstr;

			return await Task.Run(() =>
			{
				var db = _entityRepository.GetDbContext().Database;
				var conn = db.GetDbConnection();
				if (conn.State != ConnectionState.Open)
					conn.Open();

				var result = new List<T>();

				try
				{


					RelationalDataReader query = null;
					
                     using (db.GetService<IConcurrencyDetector>().EnterCriticalSection())
						                     {
						                         var rawSqlCommand = db.GetService<IRawSqlCommandBuilder>().Build(sql);
						
						                         query = rawSqlCommand.ExecuteReader(db.GetService<IRelationalConnection>());
						                     }

					//获取DbDataReader
					var dr = query.DbDataReader;

					var properties = typeof(T).GetProperties().ToList();

					while (dr.Read())
					{
						var obj = new T();
						foreach (var property in properties)
						{
							//获取该字段明的列序号，从0开始
							var id = dr.GetOrdinal(property.Name.ToLower());

							if (!dr.IsDBNull(id))
							{
								if (dr.GetValue(id) != DBNull.Value)
								{
									property.SetValue(obj, dr.GetValue(id));
								}
							}
						}

						result.Add(obj);
					}

					//关闭DbDataReader
					dr.Close();
				}
				catch (Exception e)
				{
					throw new UserFriendlyException(e.Message);
				}

				return result;
			});

		}
			
		

	}

}


