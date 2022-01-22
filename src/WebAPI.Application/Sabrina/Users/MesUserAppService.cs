
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
using WebAPI.Sabrina.Users.Dtos;
using WebAPI.Sabrina.Users.DomainService;

namespace WebAPI.Sabrina.Users
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///
	/// </summary>
    //[AbpAuthorize]
    public class MesUserAppService : WebAPIAppServiceBase , IMesUserAppService
    {
		private readonly IRepository<MesUser, long>
        _mesUserRepository;

        private readonly IMesUserManager _mesUserManager;
        /// <summary>
            /// 构造函数
            ///
        ///</summary>
        public MesUserAppService(        IRepository<MesUser, long> mesUserRepository,IMesUserManager mesUserManager)        {
			_mesUserRepository = mesUserRepository;
			_mesUserManager=mesUserManager;
		}


            /// <summary>
                /// 获取的分页列表信息
                ///
           /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            //[AbpAuthorize(MesUserPermissions.MesUser_Query)]
            public async Task<PagedResultDto<MesUserListDto>> GetPaged(GetMesUsersInput input)
		{

		var query = _mesUserRepository.GetAll()
		.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.account.Contains(input.FilterText))
		.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.password.Contains(input.FilterText))
		.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.userName.Contains(input.FilterText))
		.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.deptID.Contains(input.FilterText))
		.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.marsk.Contains(input.FilterText)
		);
    // TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();
			var mesUserList = await query
			.OrderBy(input.Sorting).AsNoTracking()
			.PageBy(input)
			.ToListAsync();

			var mesUserListDtos = ObjectMapper.Map<List<MesUserListDto>>(mesUserList);
					return new PagedResultDto<MesUserListDto>(count,mesUserListDtos);
				}


		/// <summary>
		/// 通过指定id获取MesUserListDto信息
		/// </summary>
		///[AbpAuthorize(MesUserPermissions.MesUser_Query)]
		public async Task<MesUserListDto> GetById(EntityDto<long> input)
		{
			var entity = await _mesUserRepository.GetAsync(input.Id);
			var dto = ObjectMapper.Map<MesUserListDto>(entity);
			return dto;
 		}

		/// <summary>
		/// 获取编辑 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(MesUserPermissions.MesUser_Create,MesUserPermissions.MesUser_Edit)]
		public async Task<GetMesUserForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetMesUserForEditOutput();
			MesUserEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _mesUserRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<MesUserEditDto>(entity);
			}
			else
			{
				editDto = new MesUserEditDto();
			}
			output.MesUser = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(MesUserPermissions.MesUser_Create,MesUserPermissions.MesUser_Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateMesUserInput input)
		{

			if (input.MesUser.Id.HasValue)
			{
				await Update(input.MesUser);
			}
			else
			{
				await Create(input.MesUser);
			}
		}


		/// <summary>
		/// 新增
		/// </summary>
		//[AbpAuthorize(MesUserPermissions.MesUser_Create)]
		protected virtual async Task<MesUserEditDto> Create(MesUserEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<MesUser>(input);
            //调用领域服务
            entity = await _mesUserManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<MesUserEditDto>(entity);
            return dto;
		}

		/// <summary>
		/// 编辑
		/// </summary>
		///[AbpAuthorize(MesUserPermissions.MesUser_Edit)]
		protected virtual async Task Update(MesUserEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

		 var entity = await _mesUserRepository.GetAsync(input.Id.Value);
          //  input.MapTo(entity);
          //将input属性的值赋值到entity中
             ObjectMapper.Map(input, entity);
            await _mesUserManager.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(MesUserPermissions.MesUser_Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _mesUserManager.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除MesUser的方法
		/// </summary>
		//[AbpAuthorize(MesUserPermissions.MesUser_BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _mesUserManager.BatchDelete(input);
		}

		//public async Task<List<ReceiListDto>> getOutCountQty(string org, string subinv, string line, string style, string color, string size)
		public async Task<List<MesUserListDto>> GetByAccount(string account, string pwd)
		{
			if(account is null || pwd is null)
            {
				return null;
            }
			if(account.Trim() =="" || pwd.Trim() =="")
            {
				return null;
            }

			var entityListDtos = new List<MesUserListDto>();
			var query = _mesUserRepository.GetAll().AsNoTracking()					
				.WhereIf(!account.IsNullOrWhiteSpace()  , a => a.account.Equals(account))
				.WhereIf(!pwd.IsNullOrWhiteSpace() , a => a.password.Equals(pwd));

			var entityList = await query.OrderBy(a => a.Id).ToListAsync();
			entityListDtos = ObjectMapper.Map<List<MesUserListDto>>(entityList);
			return entityListDtos;

			 
		}

		
	}
}


