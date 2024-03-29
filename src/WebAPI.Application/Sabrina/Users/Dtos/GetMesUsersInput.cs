
using Abp.Runtime.Validation;
using WebAPI.Dtos;
using WebAPI.Sabrina.Users;

namespace WebAPI.Sabrina.Users.Dtos
{
	/// <summary>
	/// 获取的传入参数Dto
	/// </summary>
    public class GetMesUsersInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
		
							//// custom codes
									
							

							//// custom codes end
    }
}
