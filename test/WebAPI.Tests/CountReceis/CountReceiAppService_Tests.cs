
using WebAPI.Sabrina.Countrecei;
using WebAPI.Sabrina.Countrecei.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.CountReceis
{
    public class CountReceiAppService_Tests : WebAPITestBase
    {
        private readonly ICountReceiAppService _countReceiAppService;

        public CountReceiAppService_Tests()
        {
            _countReceiAppService = Resolve<ICountReceiAppService>();
        }

        [Fact]
        public async Task CreateCountRecei_Test()
        {
            await _countReceiAppService.CreateOrUpdate(new CreateOrUpdateCountReceiInput
            {
                 CountRecei = new CountReceiEditDto    
                {
						   

                            Org = "test",
                            Subinv = "test",
                            line = "test",
                            style = "test",
                            StyleCount = "test",
                            qtyCount = "test",
                            receiInDate = "test",
                            status = "test",
                            ScanQtyCount = "test",
                            DifferenceQtyCount = "test",


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaCountRecei = await context.CountReceis.FirstOrDefaultAsync();
                dystopiaCountRecei.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetCountReceis_Test()
        {
            // Act
            var output = await _countReceiAppService.GetPaged(new GetCountReceisInput
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