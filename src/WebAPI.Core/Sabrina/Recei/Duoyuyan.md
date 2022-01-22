

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
                    
                     "Receiorg": "org",
                    "ReceiorgInputDesc": "请输入org",
                     
                    
                     "Receisubinv": "subinv",
                    "ReceisubinvInputDesc": "请输入subinv",
                     
                    
                     "Receiline": "line",
                    "ReceilineInputDesc": "请输入line",
                     
                    
                     "Receistyle": "style",
                    "ReceistyleInputDesc": "请输入style",
                     
                    
                     "Receicolor": "color",
                    "ReceicolorInputDesc": "请输入color",
                     
                    
                     "Receisize": "size",
                    "ReceisizeInputDesc": "请输入size",
                     
"qtyCount": "qtyCount",
                    
                     "Receipo": "po",
                    "ReceipoInputDesc": "请输入po",
                     
                    
                     "ReceiboxCount": "boxCount",
                    "ReceiboxCountInputDesc": "请输入boxCount",
                     
                    
                     "ReceireceiNumber": "receiNumber",
                    "ReceireceiNumberInputDesc": "请输入receiNumber",
                     
                    
                     "ReceireceiDate": "receiDate",
                    "ReceireceiDateInputDesc": "请输入receiDate",
                     
                    
                     "ReceireceiEmp": "receiEmp",
                    "ReceireceiEmpInputDesc": "请输入receiEmp",
                     
                    
                     "Receimark": "mark",
                    "ReceimarkInputDesc": "请输入mark",
                     
                    
                     "ReceireceiInDate": "receiInDate",
                    "ReceireceiInDateInputDesc": "请输入receiInDate",
                     
                    
                     "ReceireceiInPcName": "receiInPcName",
                    "ReceireceiInPcNameInputDesc": "请输入receiInPcName",
                     
"isFull": "isFull",
					                     
                    "Recei": "",
                    "ManageRecei": "管理",
                    "QueryRecei": "查询",
                    "CreateRecei": "添加",
                    "EditRecei": "编辑",
                    "DeleteRecei": "删除",
                    "BatchDeleteRecei": "批量删除",
                    "ExportRecei": "导出",
                    "ReceiList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的WebAPI.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "Receiorg": "Receiorg",
                    "ReceiorgInputDesc": "Please input your Receiorg",
                     
                    
                     "Receisubinv": "Receisubinv",
                    "ReceisubinvInputDesc": "Please input your Receisubinv",
                     
                    
                     "Receiline": "Receiline",
                    "ReceilineInputDesc": "Please input your Receiline",
                     
                    
                     "Receistyle": "Receistyle",
                    "ReceistyleInputDesc": "Please input your Receistyle",
                     
                    
                     "Receicolor": "Receicolor",
                    "ReceicolorInputDesc": "Please input your Receicolor",
                     
                    
                     "Receisize": "Receisize",
                    "ReceisizeInputDesc": "Please input your Receisize",
                     
"qtyCount": "qtyCount",
                    
                     "Receipo": "Receipo",
                    "ReceipoInputDesc": "Please input your Receipo",
                     
                    
                     "ReceiboxCount": "ReceiboxCount",
                    "ReceiboxCountInputDesc": "Please input your ReceiboxCount",
                     
                    
                     "ReceireceiNumber": "ReceireceiNumber",
                    "ReceireceiNumberInputDesc": "Please input your ReceireceiNumber",
                     
                    
                     "ReceireceiDate": "ReceireceiDate",
                    "ReceireceiDateInputDesc": "Please input your ReceireceiDate",
                     
                    
                     "ReceireceiEmp": "ReceireceiEmp",
                    "ReceireceiEmpInputDesc": "Please input your ReceireceiEmp",
                     
                    
                     "Receimark": "Receimark",
                    "ReceimarkInputDesc": "Please input your Receimark",
                     
                    
                     "ReceireceiInDate": "ReceireceiInDate",
                    "ReceireceiInDateInputDesc": "Please input your ReceireceiInDate",
                     
                    
                     "ReceireceiInPcName": "ReceireceiInPcName",
                    "ReceireceiInPcNameInputDesc": "Please input your ReceireceiInPcName",
                     
"isFull": "isFull",
					                     
                    "Recei": "Recei",
                    "ManageRecei": "ManageRecei",
                    "QueryRecei": "QueryRecei",
                    "CreateRecei": "CreateRecei",
                    "EditRecei": "EditRecei",
                    "DeleteRecei": "DeleteRecei",
                    "BatchDeleteRecei": "BatchDeleteRecei",
                    "ExportRecei": "ExportRecei",
                    "ReceiList": "ReceiList",
                     //的多语言配置==End
                    




```