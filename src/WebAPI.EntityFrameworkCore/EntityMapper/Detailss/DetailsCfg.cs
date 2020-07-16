

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Sabrina.Details;

namespace WebAPI.EntityMapper.Detailss
{
    public class DetailsCfg : IEntityTypeConfiguration<Details>
    {
        public void Configure(EntityTypeBuilder<Details> builder)
        {

			 
      //   builder.ToTable("Detailss", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("Detailss");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


