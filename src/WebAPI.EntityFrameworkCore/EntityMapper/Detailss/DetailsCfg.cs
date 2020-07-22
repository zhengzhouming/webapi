

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Sabrina.Details;

namespace WebAPI.EntityMapper.Detailss
{
    public class DetailsCfg : IEntityTypeConfiguration<CONDetails>
    {
        public void Configure(EntityTypeBuilder<CONDetails> builder)
        {

			 
         builder.ToTable("Detailss", YoYoAbpefCoreConsts.SchemaNames.CMS);
      //  builder.ToTable("Detailss");


		//	builder.ToTable("ConPprs", YoYoAbpefCoreConsts.SchemaNames.CMS);


			builder.Property(a => a.Detailid).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Custid).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.SerialFrom).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.BuyerItem).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Itemdesc).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Colorcode).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Size1).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.ConQty).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Qty).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Pprfno).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);




			//可以自定义配置参数内容

			//// custom codes



			//// custom codes end
		}
    }
}


