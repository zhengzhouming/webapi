
using WebAPI.Sabrina.MesWorkTagScanReceipt;
using WebAPI.Sabrina.MesWorkTagScanReceipt.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.MesWorkTagScanReceipts
{
    public class MesWorkTagScanReceiptAppService_Tests : WebAPITestBase
    {
        private readonly IMesWorkTagScanReceiptAppService _mesWorkTagScanReceiptAppService;

        public MesWorkTagScanReceiptAppService_Tests()
        {
            _mesWorkTagScanReceiptAppService = Resolve<IMesWorkTagScanReceiptAppService>();
        }

        [Fact]
        public async Task CreateMesWorkTagScanReceipt_Test()
        {
            await _mesWorkTagScanReceiptAppService.CreateOrUpdate(new CreateOrUpdateMesWorkTagScanReceiptInput
            {
                 MesWorkTagScanReceipt = new MesWorkTagScanReceiptEditDto    
                {
						   

                            Version = "test",
                            tagScanAccount = "test",
                            tagScanDateTime = "test",
                            tagScanPDASerial = "test",
                            tagScanPDAUUID = "test",


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaMesWorkTagScanReceipt = await context.MesWorkTagScanReceipts.FirstOrDefaultAsync();
                dystopiaMesWorkTagScanReceipt.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetMesWorkTagScanReceipts_Test()
        {
            // Act
            var output = await _mesWorkTagScanReceiptAppService.GetPaged(new GetMesWorkTagScanReceiptsInput
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