

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Sabrina.MesWorkTagScan;

namespace WebAPI.EntityMapper.MesWorkTagScans
{
    public class MesWorkTagScanCfg : IEntityTypeConfiguration<MesWorkTagScan>
    {
        public void Configure(EntityTypeBuilder<MesWorkTagScan> builder)
        {

			 
      //   builder.ToTable("MesWorkTagScans", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("MesWorkTagScans");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


