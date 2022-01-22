

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Sabrina.Invrecei;

namespace WebAPI.EntityMapper.Invreceis
{
    public class InvreceiCfg : IEntityTypeConfiguration<Invrecei>
    {
        public void Configure(EntityTypeBuilder<Invrecei> builder)
        {

			 
      //   builder.ToTable("Invreceis", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("Invreceis");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


