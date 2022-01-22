

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Sabrina.Recei;

namespace WebAPI.EntityMapper.Receis
{
    public class ReceiCfg : IEntityTypeConfiguration<Recei>
    {
        public void Configure(EntityTypeBuilder<Recei> builder)
        {

			 
      //   builder.ToTable("Receis", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("Receis");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


