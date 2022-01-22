
using WebAPI.Sabrina.Invrecei;
using WebAPI.Sabrina.Invrecei.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.Invreceis
{
    public class InvreceiAppService_Tests : WebAPITestBase
    {
        private readonly IInvreceiAppService _invreceiAppService;

        public InvreceiAppService_Tests()
        {
            _invreceiAppService = Resolve<IInvreceiAppService>();
        }

        [Fact]
        public async Task CreateInvrecei_Test()
        {
            await _invreceiAppService.CreateOrUpdate(new CreateOrUpdateInvreceiInput
            {
                 Invrecei = new InvreceiEditDto    
                {
						   

                            org = "test",
                            subinv = "test",
                            line = "test",
                            TagNumber = "test",
                            kg = "test",
                            scantime = "test",
                            update_date = "test",
                            create_pc = "test",
                            exeStatus = "test",


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaInvrecei = await context.Invreceis.FirstOrDefaultAsync();
                dystopiaInvrecei.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetInvreceis_Test()
        {
            // Act
            var output = await _invreceiAppService.GetPaged(new GetInvreceisInput
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