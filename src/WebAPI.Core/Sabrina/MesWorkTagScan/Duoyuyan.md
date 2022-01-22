

# 配置52ABP-PRO的多语言
 
 
**请注意：**
- 从52ABP-PRO 2.5.0的版本开始默认采用json配置多语言
- 属性名和字段不能重复否则框架会验证失败，需要你删除重复的键名

## Json的配置方法如下

在WebAPI.Core类库中，找到路径为 Localization->SourceFiles->Json文件夹下的对应文件

### 中文本地化的内容Chinese localized content

找到Json文件夹下的WebAPI-zh-Hans.json文件，复制以下代码进入即可。

> 请注意防止键名重复，产生异常

```json
                    //的多语言配置==>中文
                    
                     "MesWorkTagScantagInvoice": "tagInvoice",
                    "MesWorkTagScantagInvoiceInputDesc": "请输入tagInvoice",
                     
                    
                     "MesWorkTagScantagReceiptNumber": "tagReceiptNumber",
                    "MesWorkTagScantagReceiptNumberInputDesc": "请输入tagReceiptNumber",
                     
                    
                     "MesWorkTagScantagLocation": "tagLocation",
                    "MesWorkTagScantagLocationInputDesc": "请输入tagLocation",
                     
                    
                     "MesWorkTagScantagNumber": "tagNumber",
                    "MesWorkTagScantagNumberInputDesc": "请输入tagNumber",
                     
                    
                     "MesWorkTagScantagScanAccount": "tagScanAccount",
                    "MesWorkTagScantagScanAccountInputDesc": "请输入tagScanAccount",
                     
"tagScanDeptID": "tagScanDeptID",
                    
                     "MesWorkTagScantagScanDateTime": "tagScanDateTime",
                    "MesWorkTagScantagScanDateTimeInputDesc": "请输入tagScanDateTime",
                     
                    
                     "MesWorkTagScantagUploadDateTime": "tagUploadDateTime",
                    "MesWorkTagScantagUploadDateTimeInputDesc": "请输入tagUploadDateTime",
                     
                    
                     "MesWorkTagScantagScanPDASerial": "tagScanPDASerial",
                    "MesWorkTagScantagScanPDASerialInputDesc": "请输入tagScanPDASerial",
                     
                    
                     "MesWorkTagScantagScanPDAUUID": "tagScanPDAUUID",
                    "MesWorkTagScantagScanPDAUUIDInputDesc": "请输入tagScanPDAUUID",
                     
                    
                     "MesWorkTagScantagStyle": "tagStyle",
                    "MesWorkTagScantagStyleInputDesc": "请输入tagStyle",
                     
                    
                     "MesWorkTagScantagColor": "tagColor",
                    "MesWorkTagScantagColorInputDesc": "请输入tagColor",
                     
                    
                     "MesWorkTagScantagSize": "tagSize",
                    "MesWorkTagScantagSizeInputDesc": "请输入tagSize",
                     
                    "tagQty": "tagQty",
                    "isUploaded": "isUploaded",
                    "isSyncMesData": "isSyncMesData",
                    "isPrints": "isPrints",
                    "tagInvoiceVersion": "tagInvoiceVersion",
                    "isInOrOut": "isInOrOut",
                    "isDels": "isDels",
                    "tagOrg": "tagOrg",
                    "tagLine": "tagLine",
					                     
                    "MesWorkTagScan": "",
                    "ManageMesWorkTagScan": "管理",
                    "QueryMesWorkTagScan": "查询",
                    "CreateMesWorkTagScan": "添加",
                    "EditMesWorkTagScan": "编辑",
                    "DeleteMesWorkTagScan": "删除",
                    "BatchDeleteMesWorkTagScan": "批量删除",
                    "ExportMesWorkTagScan": "导出",
                    "MesWorkTagScanList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的WebAPI.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "MesWorkTagScantagInvoice": "MesWorkTagScantagInvoice",
                    "MesWorkTagScantagInvoiceInputDesc": "Please input your MesWorkTagScantagInvoice",
                     
                    
                     "MesWorkTagScantagReceiptNumber": "MesWorkTagScantagReceiptNumber",
                    "MesWorkTagScantagReceiptNumberInputDesc": "Please input your MesWorkTagScantagReceiptNumber",
                     
                    
                     "MesWorkTagScantagLocation": "MesWorkTagScantagLocation",
                    "MesWorkTagScantagLocationInputDesc": "Please input your MesWorkTagScantagLocation",
                     
                    
                     "MesWorkTagScantagNumber": "MesWorkTagScantagNumber",
                    "MesWorkTagScantagNumberInputDesc": "Please input your MesWorkTagScantagNumber",
                     
                    
                     "MesWorkTagScantagScanAccount": "MesWorkTagScantagScanAccount",
                    "MesWorkTagScantagScanAccountInputDesc": "Please input your MesWorkTagScantagScanAccount",
                     
"tagScanDeptID": "tagScanDeptID",
                    
                     "MesWorkTagScantagScanDateTime": "MesWorkTagScantagScanDateTime",
                    "MesWorkTagScantagScanDateTimeInputDesc": "Please input your MesWorkTagScantagScanDateTime",
                     
                    
                     "MesWorkTagScantagUploadDateTime": "MesWorkTagScantagUploadDateTime",
                    "MesWorkTagScantagUploadDateTimeInputDesc": "Please input your MesWorkTagScantagUploadDateTime",
                     
                    
                     "MesWorkTagScantagScanPDASerial": "MesWorkTagScantagScanPDASerial",
                    "MesWorkTagScantagScanPDASerialInputDesc": "Please input your MesWorkTagScantagScanPDASerial",
                     
                    
                     "MesWorkTagScantagScanPDAUUID": "MesWorkTagScantagScanPDAUUID",
                    "MesWorkTagScantagScanPDAUUIDInputDesc": "Please input your MesWorkTagScantagScanPDAUUID",
                     
                    
                     "MesWorkTagScantagStyle": "MesWorkTagScantagStyle",
                    "MesWorkTagScantagStyleInputDesc": "Please input your MesWorkTagScantagStyle",
                     
                    
                     "MesWorkTagScantagColor": "MesWorkTagScantagColor",
                    "MesWorkTagScantagColorInputDesc": "Please input your MesWorkTagScantagColor",
                     
                    
                     "MesWorkTagScantagSize": "MesWorkTagScantagSize",
                    "MesWorkTagScantagSizeInputDesc": "Please input your MesWorkTagScantagSize",
                     
                    "tagQty": "tagQty",
                    "isUploaded": "isUploaded",
                    "isSyncMesData": "isSyncMesData",
                    "isPrints": "isPrints",
                    "tagInvoiceVersion": "tagInvoiceVersion",
                    "isInOrOut": "isInOrOut",
                    "isDels": "isDels",
                    "tagOrg": "tagOrg",
                    "tagLine": "tagLine",
					                     
                    "MesWorkTagScan": "MesWorkTagScan",
                    "ManageMesWorkTagScan": "ManageMesWorkTagScan",
                    "QueryMesWorkTagScan": "QueryMesWorkTagScan",
                    "CreateMesWorkTagScan": "CreateMesWorkTagScan",
                    "EditMesWorkTagScan": "EditMesWorkTagScan",
                    "DeleteMesWorkTagScan": "DeleteMesWorkTagScan",
                    "BatchDeleteMesWorkTagScan": "BatchDeleteMesWorkTagScan",
                    "ExportMesWorkTagScan": "ExportMesWorkTagScan",
                    "MesWorkTagScanList": "MesWorkTagScanList",
                     //的多语言配置==End
                    




```