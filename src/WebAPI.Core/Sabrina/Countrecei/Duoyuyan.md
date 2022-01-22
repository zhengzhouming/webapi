

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
                    
                     "CountReceiOrg": "Org",
                    "CountReceiOrgInputDesc": "请输入Org",
                     
                    
                     "CountReceiSubinv": "Subinv",
                    "CountReceiSubinvInputDesc": "请输入Subinv",
                     
                    
                     "CountReceiline": "line",
                    "CountReceilineInputDesc": "请输入line",
                     
                    
                     "CountReceistyle": "style",
                    "CountReceistyleInputDesc": "请输入style",
                     
                    
                     "CountReceiStyleCount": "StyleCount",
                    "CountReceiStyleCountInputDesc": "请输入StyleCount",
                     
                    
                     "CountReceiqtyCount": "qtyCount",
                    "CountReceiqtyCountInputDesc": "请输入qtyCount",
                     
                    
                     "CountReceireceiInDate": "receiInDate",
                    "CountReceireceiInDateInputDesc": "请输入receiInDate",
                     
                    
                     "CountReceistatus": "status",
                    "CountReceistatusInputDesc": "请输入status",
                     
                    
                     "CountReceiScanQtyCount": "ScanQtyCount",
                    "CountReceiScanQtyCountInputDesc": "请输入ScanQtyCount",
                     
                    
                     "CountReceiDifferenceQtyCount": "DifferenceQtyCount",
                    "CountReceiDifferenceQtyCountInputDesc": "请输入DifferenceQtyCount",
                     
					                     
                    "CountRecei": "",
                    "ManageCountRecei": "管理",
                    "QueryCountRecei": "查询",
                    "CreateCountRecei": "添加",
                    "EditCountRecei": "编辑",
                    "DeleteCountRecei": "删除",
                    "BatchDeleteCountRecei": "批量删除",
                    "ExportCountRecei": "导出",
                    "CountReceiList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的WebAPI.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "CountReceiOrg": "CountReceiOrg",
                    "CountReceiOrgInputDesc": "Please input your CountReceiOrg",
                     
                    
                     "CountReceiSubinv": "CountReceiSubinv",
                    "CountReceiSubinvInputDesc": "Please input your CountReceiSubinv",
                     
                    
                     "CountReceiline": "CountReceiline",
                    "CountReceilineInputDesc": "Please input your CountReceiline",
                     
                    
                     "CountReceistyle": "CountReceistyle",
                    "CountReceistyleInputDesc": "Please input your CountReceistyle",
                     
                    
                     "CountReceiStyleCount": "CountReceiStyleCount",
                    "CountReceiStyleCountInputDesc": "Please input your CountReceiStyleCount",
                     
                    
                     "CountReceiqtyCount": "CountReceiqtyCount",
                    "CountReceiqtyCountInputDesc": "Please input your CountReceiqtyCount",
                     
                    
                     "CountReceireceiInDate": "CountReceireceiInDate",
                    "CountReceireceiInDateInputDesc": "Please input your CountReceireceiInDate",
                     
                    
                     "CountReceistatus": "CountReceistatus",
                    "CountReceistatusInputDesc": "Please input your CountReceistatus",
                     
                    
                     "CountReceiScanQtyCount": "CountReceiScanQtyCount",
                    "CountReceiScanQtyCountInputDesc": "Please input your CountReceiScanQtyCount",
                     
                    
                     "CountReceiDifferenceQtyCount": "CountReceiDifferenceQtyCount",
                    "CountReceiDifferenceQtyCountInputDesc": "Please input your CountReceiDifferenceQtyCount",
                     
					                     
                    "CountRecei": "CountRecei",
                    "ManageCountRecei": "ManageCountRecei",
                    "QueryCountRecei": "QueryCountRecei",
                    "CreateCountRecei": "CreateCountRecei",
                    "EditCountRecei": "EditCountRecei",
                    "DeleteCountRecei": "DeleteCountRecei",
                    "BatchDeleteCountRecei": "BatchDeleteCountRecei",
                    "ExportCountRecei": "ExportCountRecei",
                    "CountReceiList": "CountReceiList",
                     //的多语言配置==End
                    




```