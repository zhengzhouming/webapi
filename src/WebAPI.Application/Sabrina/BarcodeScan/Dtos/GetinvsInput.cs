
using Abp.Runtime.Validation;
using WebAPI.Dtos;
using WebAPI.Sabrina.barcodeScan;

namespace WebAPI.Sabrina.barcodeScan.Dtos
{
    public class GetinvsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
