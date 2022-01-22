using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using WebAPI.Sabrina.Countrecei.DomainService;
using WebAPI.Sabrina.Countrecei.Dtos;

namespace WebAPI.Sabrina.Countrecei
{
    /// <summary>
    ///     应用层服务的接口实现方法
    /// </summary>
    // [AbpAuthorize]
    public class CountReceiAppService : WebAPIAppServiceBase, ICountReceiAppService
    {
        private readonly IRepository<Countrecei, long> _countReceiRepository;


        private readonly ICountReceiManager _countReceiManager;

        /// <summary>
        ///     构造函数
        /// </summary>
        public CountReceiAppService(
            IRepository<Countrecei, long> countReceiRepository
            , ICountReceiManager countReceiManager
        )
        {
            _countReceiRepository = countReceiRepository;
            _countReceiManager = countReceiManager;
        }


        /// <summary>
        ///     获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //  [AbpAuthorize(CountReceiPermissions.CountRecei_Query)]
        public async Task<PagedResultDto<CountReceiListDto>> GetPaged(GetCountReceisInput input)
        {
            var query = _countReceiRepository.GetAll()

                    //模糊搜索Org
                    .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Org.Contains(input.FilterText))
                    //模糊搜索Subinv
                    .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Subinv.Contains(input.FilterText))
                    //模糊搜索line
                    .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.line.Contains(input.FilterText))
                    //模糊搜索style
                    .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.style.Contains(input.FilterText))
                    //模糊搜索StyleCount
                    .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.StyleCount.Contains(input.FilterText))
                    //模糊搜索qtyCount
                    .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.qtyCount.Contains(input.FilterText))
                    //模糊搜索receiInDate
                    .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.receiInDate.Contains(input.FilterText))
                    //模糊搜索status
                    .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.status.Contains(input.FilterText))
                    //模糊搜索ScanQtyCount
                    .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ScanQtyCount.Contains(input.FilterText))
                    //模糊搜索DifferenceQtyCount
                    .WhereIf(!input.FilterText.IsNullOrWhiteSpace(),
                        a => a.DifferenceQtyCount.Contains(input.FilterText))
                ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var countReceiList = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();
            var countReceiListDtos = ObjectMapper.Map<List<CountReceiListDto>>(countReceiList);
            return new PagedResultDto<CountReceiListDto>(count, countReceiListDtos);
        }


        public async Task<List<CountReceiListDto>> getOutCountQty(string org, string subinv, string line, string style)
        {
            var entityListDtos = new List<CountReceiListDto>();
            if (org.IsNullOrWhiteSpace()) return null;
            if (subinv.IsNullOrWhiteSpace()) return null;
            if (line.IsNullOrWhiteSpace()) return null;
            if (style.IsNullOrWhiteSpace()) return null;
            var query = _countReceiRepository.GetAll().AsNoTracking()
                .WhereIf(!org.IsNullOrWhiteSpace(), a => a.Org.Equals(org))
                .WhereIf(!subinv.IsNullOrWhiteSpace(), a => a.Subinv.Equals(subinv))
                .WhereIf(!line.IsNullOrWhiteSpace(), a => a.line.Equals(line))
                .WhereIf(!style.IsNullOrWhiteSpace(), a => a.style.Equals(style));

            var entityList = await query.OrderBy(a => a.Id).ToListAsync();
            entityListDtos = ObjectMapper.Map<List<CountReceiListDto>>(entityList);
            return entityListDtos;
        }


        /// <summary>
        ///     通过指定id获取CountReceiListDto信息
        /// </summary>
        //[AbpAuthorize(CountReceiPermissions.CountRecei_Query)]
        public async Task<CountReceiListDto> GetById(EntityDto<long> input)
        {
            var entity = await _countReceiRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<CountReceiListDto>(entity);
            return dto;
        }

        /// <summary>
        ///     获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CountReceiPermissions.CountRecei_Create,CountReceiPermissions.CountRecei_Edit)]
        public async Task<GetCountReceiForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetCountReceiForEditOutput();
            CountReceiEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _countReceiRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<CountReceiEditDto>(entity);
            }
            else
            {
                editDto = new CountReceiEditDto();
            }


            output.CountRecei = editDto;
            return output;
        }


        /// <summary>
        ///     添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //	[AbpAuthorize(CountReceiPermissions.CountRecei_Create,CountReceiPermissions.CountRecei_Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateCountReceiInput input)
        {
            if (input.CountRecei.Id.HasValue)
                await Update(input.CountRecei);
            else
                await Create(input.CountRecei);
        }


        /// <summary>
        ///     新增
        /// </summary>
        //[AbpAuthorize(CountReceiPermissions.CountRecei_Create)]
        protected virtual async Task<CountReceiEditDto> Create(CountReceiEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<Countrecei>(input);
            //调用领域服务
            entity = await _countReceiManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<CountReceiEditDto>(entity);
            return dto;
        }

        /// <summary>
        ///     编辑
        /// </summary>
        // [AbpAuthorize(CountReceiPermissions.CountRecei_Edit)]
        protected virtual async Task Update(CountReceiEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _countReceiRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _countReceiManager.UpdateAsync(entity);
        }


        /// <summary>
        ///     删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //  [AbpAuthorize(CountReceiPermissions.CountRecei_Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _countReceiManager.DeleteAsync(input.Id);
        }


        /// <summary>
        ///     批量删除CountRecei的方法
        /// </summary>
        //  [AbpAuthorize(CountReceiPermissions.CountRecei_BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _countReceiManager.BatchDelete(input);
        }


        //// custom codes


        //// custom codes end
    }
}