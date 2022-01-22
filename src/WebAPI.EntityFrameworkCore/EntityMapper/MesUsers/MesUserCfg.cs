

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Sabrina.Users;

namespace WebAPI.EntityMapper.MesUsers
{
    public class MesUserCfg : IEntityTypeConfiguration<MesUser>
    {
        public void Configure(EntityTypeBuilder<MesUser> builder)
        {

			 
      //   builder.ToTable("MesUsers", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("MesUsers");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


