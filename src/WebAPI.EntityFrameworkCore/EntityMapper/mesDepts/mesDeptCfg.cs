

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Sabrina.MesDept;

namespace WebAPI.EntityMapper.MesDepts
{
    public class MesDeptCfg : IEntityTypeConfiguration<MesDept>
    {
        public void Configure(EntityTypeBuilder<MesDept> builder)
        {

			 
      //   builder.ToTable("MesDepts", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("MesDepts");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


