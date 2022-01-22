

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Sabrina.Countrecei;

namespace WebAPI.EntityMapper.CountReceis
{
    public class CountReceiCfg : IEntityTypeConfiguration<Countrecei>
    {
        public void Configure(EntityTypeBuilder<Countrecei> builder)
        {

			 
      //   builder.ToTable("CountReceis", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("CountReceis");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


