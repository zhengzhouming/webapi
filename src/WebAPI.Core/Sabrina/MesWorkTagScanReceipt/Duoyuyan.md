

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
                    
                     "MesWorkTagScanReceiptVersion": "Version",
                    "MesWorkTagScanReceiptVersionInputDesc": "请输入Version",
                     
                    
                     "MesWorkTagScanReceipttagScanAccount": "tagScanAccount",
                    "MesWorkTagScanReceipttagScanAccountInputDesc": "请输入tagScanAccount",
                     
"tagScanDeptID": "tagScanDeptID",
                    
                     "MesWorkTagScanReceipttagScanDateTime": "tagScanDateTime",
                    "MesWorkTagScanReceipttagScanDateTimeInputDesc": "请输入tagScanDateTime",
                     
                    
                     "MesWorkTagScanReceipttagScanPDASerial": "tagScanPDASerial",
                    "MesWorkTagScanReceipttagScanPDASerialInputDesc": "请输入tagScanPDASerial",
                     
                    
                     "MesWorkTagScanReceipttagScanPDAUUID": "tagScanPDAUUID",
                    "MesWorkTagScanReceipttagScanPDAUUIDInputDesc": "请输入tagScanPDAUUID",
                     
					                     
                    "MesWorkTagScanReceipt": "",
                    "ManageMesWorkTagScanReceipt": "管理",
                    "QueryMesWorkTagScanReceipt": "查询",
                    "CreateMesWorkTagScanReceipt": "添加",
                    "EditMesWorkTagScanReceipt": "编辑",
                    "DeleteMesWorkTagScanReceipt": "删除",
                    "BatchDeleteMesWorkTagScanReceipt": "批量删除",
                    "ExportMesWorkTagScanReceipt": "导出",
                    "MesWorkTagScanReceiptList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的WebAPI.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "MesWorkTagScanReceiptVersion": "MesWorkTagScanReceiptVersion",
                    "MesWorkTagScanReceiptVersionInputDesc": "Please input your MesWorkTagScanReceiptVersion",
                     
                    
                     "MesWorkTagScanReceipttagScanAccount": "MesWorkTagScanReceipttagScanAccount",
                    "MesWorkTagScanReceipttagScanAccountInputDesc": "Please input your MesWorkTagScanReceipttagScanAccount",
                     
"tagScanDeptID": "tagScanDeptID",
                    
                     "MesWorkTagScanReceipttagScanDateTime": "MesWorkTagScanReceipttagScanDateTime",
                    "MesWorkTagScanReceipttagScanDateTimeInputDesc": "Please input your MesWorkTagScanReceipttagScanDateTime",
                     
                    
                     "MesWorkTagScanReceipttagScanPDASerial": "MesWorkTagScanReceipttagScanPDASerial",
                    "MesWorkTagScanReceipttagScanPDASerialInputDesc": "Please input your MesWorkTagScanReceipttagScanPDASerial",
                     
                    
                     "MesWorkTagScanReceipttagScanPDAUUID": "MesWorkTagScanReceipttagScanPDAUUID",
                    "MesWorkTagScanReceipttagScanPDAUUIDInputDesc": "Please input your MesWorkTagScanReceipttagScanPDAUUID",
                     
					                     
                    "MesWorkTagScanReceipt": "MesWorkTagScanReceipt",
                    "ManageMesWorkTagScanReceipt": "ManageMesWorkTagScanReceipt",
                    "QueryMesWorkTagScanReceipt": "QueryMesWorkTagScanReceipt",
                    "CreateMesWorkTagScanReceipt": "CreateMesWorkTagScanReceipt",
                    "EditMesWorkTagScanReceipt": "EditMesWorkTagScanReceipt",
                    "DeleteMesWorkTagScanReceipt": "DeleteMesWorkTagScanReceipt",
                    "BatchDeleteMesWorkTagScanReceipt": "BatchDeleteMesWorkTagScanReceipt",
                    "ExportMesWorkTagScanReceipt": "ExportMesWorkTagScanReceipt",
                    "MesWorkTagScanReceiptList": "MesWorkTagScanReceiptList",
                     //的多语言配置==End
                    




```