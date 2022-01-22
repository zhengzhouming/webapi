
using WebAPI.Sabrina.MesDept;
using WebAPI.Sabrina.MesDept.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.MesDepts
{
    public class MesDeptAppService_Tests : WebAPITestBase
    {
        private readonly IMesDeptAppService _MesDeptAppService;

        public MesDeptAppService_Tests()
        {
            _MesDeptAppService = Resolve<IMesDeptAppService>();
        }

        [Fact]
        public async Task CreateMesDept_Test()
        {
            await _MesDeptAppService.CreateOrUpdate(new CreateOrUpdateMesDeptInput
            {
                 MesDept = new MesDeptEditDto    
                {
						   

                            DeptName = "test",
                            DeptNumber = "test",
                            Marsk = "test",


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaMesDept = await context.MesDepts.FirstOrDefaultAsync();
                dystopiaMesDept.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetMesDepts_Test()
        {
            // Act
            var output = await _MesDeptAppService.GetPaged(new GetMesDeptsInput
            {
                MaxResultCount = 20,
                SkipCount = 0
            });

            // Assert
            output.Items.Count.ShouldBeGreaterThanOrEqualTo(0);
        }

		
							//// custom codes
									
							

							//// custom codes end


    }
}