namespace WebAPI.Sabrina.MesWorkTagScan.Exporting
{
    /*
    /// <summary>
    /// 的视图模型根据业务需要可以导出为Excel文件
    /// </summary>
	[RemoteService(IsEnabled = false)]
    public class MesWorkTagScanListExcelExporter : EpplusExcelExporterBase, IMesWorkTagScanListExcelExporter
    {       
        /// <summary>
        /// 构造函数，需要继承父类
        /// </summary>
        /// <param name="dataTempFileCacheManager"></param>
        public MesWorkTagScanListExcelExporter(IDataTempFileCacheManager dataTempFileCacheManager):base(dataTempFileCacheManager)
        {

        }
        public FileDto ExportToExcelFile(List<MesWorkTagScanListDto> mesWorkTagScanListDtos)
        {

    var fileExportName = L("MesWorkTagScanList") + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            var excel =
                 CreateExcelPackage(fileExportName, excelpackage =>
               {
                   var sheet = excelpackage.Workbook.Worksheets.Add(L("MesWorkTagScans"));

                   sheet.OutLineApplyStyle = true;

			AddHeader(sheet,L("MesWorkTagScantagInvoice"),L("MesWorkTagScantagReceiptNumber"),L("MesWorkTagScantagLocation"),L("MesWorkTagScantagNumber"),L("MesWorkTagScantagScanAccount"),L("tagScanDeptID"),L("MesWorkTagScantagScanDateTime"),L("MesWorkTagScantagUploadDateTime"),L("MesWorkTagScantagScanPDASerial"),L("MesWorkTagScantagScanPDAUUID"),L("MesWorkTagScantagStyle"),L("MesWorkTagScantagColor"),L("MesWorkTagScantagSize"),L("tagQty"),L("isUploaded"),L("isSyncMesData"),L("isPrints"),L("tagInvoiceVersion"),L("isInOrOut"),L("isDels"));
            AddObject(sheet, 2, mesWorkTagScanListDtos
             ,ex => ex.tagInvoice 
             ,ex => ex.tagReceiptNumber 
             ,ex => ex.tagLocation 
             ,ex => ex.tagNumber 
             ,ex => ex.tagScanAccount 
             ,ex => ex.tagScanDeptID 
             ,ex => ex.tagScanDateTime 
             ,ex => ex.tagUploadDateTime 
             ,ex => ex.tagScanPDASerial 
             ,ex => ex.tagScanPDAUUID 
             ,ex => ex.tagStyle 
             ,ex => ex.tagColor 
             ,ex => ex.tagSize 
             ,ex => ex.tagQty 
             ,ex => ex.isUploaded 
             ,ex => ex.isSyncMesData 
             ,ex => ex.isPrints 
             ,ex => ex.tagInvoiceVersion 
             ,ex => ex.isInOrOut 
             ,ex => ex.isDels 
                   );

							//// custom codes
									
							

							//// custom codes end
	  });
    return excel;
        }
    }
    */
}
