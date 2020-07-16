
using WebAPI.Sabrina.Details;
using WebAPI.Sabrina.Details.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.Detailss
{
    public class DetailsAppService_Tests : WebAPITestBase
    {
        private readonly IDetailsAppService _detailsAppService;

        public DetailsAppService_Tests()
        {
            _detailsAppService = Resolve<IDetailsAppService>();
        }

        [Fact]
        public async Task CreateDetails_Test()
        {
            await _detailsAppService.CreateOrUpdate(new CreateOrUpdateDetailsInput
            {
                 Details = new DetailsEditDto    
                {
						   

                            Detailid = "test",
                            Custid = "test",
                            SerialFrom = "test",
                            BuyerItem = "test",
                            Itemdesc = "test",
                            Colorcode = "test",
                            Size1 = "test",
                            Pprfno = "test",


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaDetails = await context.Detailss.FirstOrDefaultAsync();
                dystopiaDetails.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetDetailss_Test()
        {
            // Act
            var output = await _detailsAppService.GetPaged(new GetDetailssInput
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