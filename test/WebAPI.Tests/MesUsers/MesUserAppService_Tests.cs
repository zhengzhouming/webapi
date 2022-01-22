
using WebAPI.Sabrina.Users;
using WebAPI.Sabrina.Users.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.MesUsers
{
    public class MesUserAppService_Tests : WebAPITestBase
    {
        private readonly IMesUserAppService _mesUserAppService;

        public MesUserAppService_Tests()
        {
            _mesUserAppService = Resolve<IMesUserAppService>();
        }

        [Fact]
        public async Task CreateMesUser_Test()
        {
            await _mesUserAppService.CreateOrUpdate(new CreateOrUpdateMesUserInput
            {
                 MesUser = new MesUserEditDto    
                {
						   

                            account = "test",
                            password = "test",
                            userName = "test",
                            deptID = "test",
                            marsk = "test",


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaMesUser = await context.MesUsers.FirstOrDefaultAsync();
                dystopiaMesUser.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetMesUsers_Test()
        {
            // Act
            var output = await _mesUserAppService.GetPaged(new GetMesUsersInput
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