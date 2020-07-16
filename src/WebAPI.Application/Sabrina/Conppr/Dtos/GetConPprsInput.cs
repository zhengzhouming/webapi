
using Abp.Runtime.Validation;
using WebAPI.Dtos;
using WebAPI.Sabrina.Conppr;

namespace WebAPI.Sabrina.Conppr.Dtos
{
    public class GetConPprsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
