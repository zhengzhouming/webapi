
using Abp.Runtime.Validation;
using WebAPI.Dtos;
using WebAPI.Sabrina.Locations;

namespace WebAPI.Sabrina.Locations.Dtos
{
    public class GetLocationssInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
