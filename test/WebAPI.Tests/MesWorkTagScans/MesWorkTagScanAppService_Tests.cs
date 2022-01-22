
using WebAPI.Sabrina.MesWorkTagScan;
using WebAPI.Sabrina.MesWorkTagScan.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.MesWorkTagScans
{
    public class MesWorkTagScanAppService_Tests : WebAPITestBase
    {
        private readonly IMesWorkTagScanAppService _mesWorkTagScanAppService;

        public MesWorkTagScanAppService_Tests()
        {
            _mesWorkTagScanAppService = Resolve<IMesWorkTagScanAppService>();
        }

        [Fact]
        public async Task CreateMesWorkTagScan_Test()
        {
            await _mesWorkTagScanAppService.CreateOrUpdate(new CreateOrUpdateMesWorkTagScanInput
            {
                 MesWorkTagScan = new MesWorkTagScanEditDto    
                {
						   

                            tagInvoice = "test",
                            tagReceiptNumber = "test",
                            tagLocation = "test",
                            tagNumber = "test",
                            tagScanAccount = "test",
                            tagScanDateTime = "test",
                            tagUploadDateTime = "test",
                            tagScanPDASerial = "test",
                            tagScanPDAUUID = "test",
                            tagStyle = "test",
                            tagColor = "test",
                            tagSize = "test",


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaMesWorkTagScan = await context.MesWorkTagScans.FirstOrDefaultAsync();
                dystopiaMesWorkTagScan.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetMesWorkTagScans_Test()
        {
            // Act
            var output = await _mesWorkTagScanAppService.GetPaged(new GetMesWorkTagScansInput
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