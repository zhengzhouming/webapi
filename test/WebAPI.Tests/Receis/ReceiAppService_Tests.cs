
using WebAPI.Sabrina.Recei;
using WebAPI.Sabrina.Recei.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.Receis
{
    public class ReceiAppService_Tests : WebAPITestBase
    {
        private readonly IReceiAppService _receiAppService;

        public ReceiAppService_Tests()
        {
            _receiAppService = Resolve<IReceiAppService>();
        }

        [Fact]
        public async Task CreateRecei_Test()
        {
            await _receiAppService.CreateOrUpdate(new CreateOrUpdateReceiInput
            {
                 Recei = new ReceiEditDto    
                {
						   

                            org = "test",
                            subinv = "test",
                            line = "test",
                            style = "test",
                            color = "test",
                            size = "test",
                            po = "test",
                            boxCount = "test",
                            receiNumber = "test",
                            receiDate = "test",
                            receiEmp = "test",
                            mark = "test",
                            receiInDate = "test",
                            receiInPcName = "test",


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaRecei = await context.Receis.FirstOrDefaultAsync();
                dystopiaRecei.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetReceis_Test()
        {
            // Act
            var output = await _receiAppService.GetPaged(new GetReceisInput
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