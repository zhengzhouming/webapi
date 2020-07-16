

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
                    
                     "DetailsDetailid": "Detailid",
                    "DetailsDetailidInputDesc": "请输入Detailid",
                     
                    
                     "DetailsCustid": "Custid",
                    "DetailsCustidInputDesc": "请输入Custid",
                     
                    
                     "DetailsSerialFrom": "SerialFrom",
                    "DetailsSerialFromInputDesc": "请输入SerialFrom",
                     
                    
                     "DetailsBuyerItem": "BuyerItem",
                    "DetailsBuyerItemInputDesc": "请输入BuyerItem",
                     
                    
                     "DetailsItemdesc": "Itemdesc",
                    "DetailsItemdescInputDesc": "请输入Itemdesc",
                     
                    
                     "DetailsColorcode": "Colorcode",
                    "DetailsColorcodeInputDesc": "请输入Colorcode",
                     
                    
                     "DetailsSize1": "Size1",
                    "DetailsSize1InputDesc": "请输入Size1",
                     
"ConQty": "ConQty",
"Qty": "Qty",
                    
                     "DetailsPprfno": "Pprfno",
                    "DetailsPprfnoInputDesc": "请输入Pprfno",
                     
					                     
                    "Details": "",
                    "ManageDetails": "管理",
                    "QueryDetails": "查询",
                    "CreateDetails": "添加",
                    "EditDetails": "编辑",
                    "DeleteDetails": "删除",
                    "BatchDeleteDetails": "批量删除",
                    "ExportDetails": "导出",
                    "DetailsList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的WebAPI.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "DetailsDetailid": "DetailsDetailid",
                    "DetailsDetailidInputDesc": "Please input your DetailsDetailid",
                     
                    
                     "DetailsCustid": "DetailsCustid",
                    "DetailsCustidInputDesc": "Please input your DetailsCustid",
                     
                    
                     "DetailsSerialFrom": "DetailsSerialFrom",
                    "DetailsSerialFromInputDesc": "Please input your DetailsSerialFrom",
                     
                    
                     "DetailsBuyerItem": "DetailsBuyerItem",
                    "DetailsBuyerItemInputDesc": "Please input your DetailsBuyerItem",
                     
                    
                     "DetailsItemdesc": "DetailsItemdesc",
                    "DetailsItemdescInputDesc": "Please input your DetailsItemdesc",
                     
                    
                     "DetailsColorcode": "DetailsColorcode",
                    "DetailsColorcodeInputDesc": "Please input your DetailsColorcode",
                     
                    
                     "DetailsSize1": "DetailsSize1",
                    "DetailsSize1InputDesc": "Please input your DetailsSize1",
                     
"ConQty": "ConQty",
"Qty": "Qty",
                    
                     "DetailsPprfno": "DetailsPprfno",
                    "DetailsPprfnoInputDesc": "Please input your DetailsPprfno",
                     
					                     
                    "Details": "Details",
                    "ManageDetails": "ManageDetails",
                    "QueryDetails": "QueryDetails",
                    "CreateDetails": "CreateDetails",
                    "EditDetails": "EditDetails",
                    "DeleteDetails": "DeleteDetails",
                    "BatchDeleteDetails": "BatchDeleteDetails",
                    "ExportDetails": "ExportDetails",
                    "DetailsList": "DetailsList",
                     //的多语言配置==End
                    




```