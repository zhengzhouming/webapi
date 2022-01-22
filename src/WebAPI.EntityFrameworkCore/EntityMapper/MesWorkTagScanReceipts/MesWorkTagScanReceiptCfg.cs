

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Sabrina.MesWorkTagScanReceipt;

namespace WebAPI.EntityMapper.MesWorkTagScanReceipts
{
    public class MesWorkTagScanReceiptCfg : IEntityTypeConfiguration<MesWorkTagScanReceipt>
    {
        public void Configure(EntityTypeBuilder<MesWorkTagScanReceipt> builder)
        {

			 
      //   builder.ToTable("MesWorkTagScanReceipts", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("MesWorkTagScanReceipts");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


