
using System.Collections.Generic;
using L._52ABP.Application.Dtos;
using WebAPI.Sabrina.MesWorkTagScan.Dtos;

namespace WebAPI.Sabrina.MesWorkTagScan.Exporting
{
    public interface IMesWorkTagScanListExcelExporter
    {
        /// <summary>
        /// 导出为Excel文件
        /// </summary>
        /// <param name="mesWorkTagScanListDtos">传入的数据集合</param>
        /// <returns></returns>
        FileDto ExportToExcelFile(List<MesWorkTagScanListDto> mesWorkTagScanListDtos);

		
							//// custom codes
									
							

							//// custom codes end
    }
}