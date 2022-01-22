

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
                    
                     "Invreceiorg": "org",
                    "InvreceiorgInputDesc": "请输入org",
                     
                    
                     "Invreceisubinv": "subinv",
                    "InvreceisubinvInputDesc": "请输入subinv",
                     
                    
                     "Invreceiline": "line",
                    "InvreceilineInputDesc": "请输入line",
                     
                    
                     "InvreceiTagNumber": "TagNumber",
                    "InvreceiTagNumberInputDesc": "请输入TagNumber",
                     
                    
                     "Invreceikg": "kg",
                    "InvreceikgInputDesc": "请输入kg",
                     
                    
                     "Invreceiscantime": "scantime",
                    "InvreceiscantimeInputDesc": "请输入scantime",
                     
                    
                     "Invreceiupdate_date": "update_date",
                    "Invreceiupdate_dateInputDesc": "请输入update_date",
                     
                    
                     "Invreceicreate_pc": "create_pc",
                    "Invreceicreate_pcInputDesc": "请输入create_pc",
                     
                    
                     "InvreceiexeStatus": "exeStatus",
                    "InvreceiexeStatusInputDesc": "请输入exeStatus",
                     
					                     
                    "Invrecei": "",
                    "ManageInvrecei": "管理",
                    "QueryInvrecei": "查询",
                    "CreateInvrecei": "添加",
                    "EditInvrecei": "编辑",
                    "DeleteInvrecei": "删除",
                    "BatchDeleteInvrecei": "批量删除",
                    "ExportInvrecei": "导出",
                    "InvreceiList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的WebAPI.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "Invreceiorg": "Invreceiorg",
                    "InvreceiorgInputDesc": "Please input your Invreceiorg",
                     
                    
                     "Invreceisubinv": "Invreceisubinv",
                    "InvreceisubinvInputDesc": "Please input your Invreceisubinv",
                     
                    
                     "Invreceiline": "Invreceiline",
                    "InvreceilineInputDesc": "Please input your Invreceiline",
                     
                    
                     "InvreceiTagNumber": "InvreceiTagNumber",
                    "InvreceiTagNumberInputDesc": "Please input your InvreceiTagNumber",
                     
                    
                     "Invreceikg": "Invreceikg",
                    "InvreceikgInputDesc": "Please input your Invreceikg",
                     
                    
                     "Invreceiscantime": "Invreceiscantime",
                    "InvreceiscantimeInputDesc": "Please input your Invreceiscantime",
                     
                    
                     "Invreceiupdate_date": "Invreceiupdate_date",
                    "Invreceiupdate_dateInputDesc": "Please input your Invreceiupdate_date",
                     
                    
                     "Invreceicreate_pc": "Invreceicreate_pc",
                    "Invreceicreate_pcInputDesc": "Please input your Invreceicreate_pc",
                     
                    
                     "InvreceiexeStatus": "InvreceiexeStatus",
                    "InvreceiexeStatusInputDesc": "Please input your InvreceiexeStatus",
                     
					                     
                    "Invrecei": "Invrecei",
                    "ManageInvrecei": "ManageInvrecei",
                    "QueryInvrecei": "QueryInvrecei",
                    "CreateInvrecei": "CreateInvrecei",
                    "EditInvrecei": "EditInvrecei",
                    "DeleteInvrecei": "DeleteInvrecei",
                    "BatchDeleteInvrecei": "BatchDeleteInvrecei",
                    "ExportInvrecei": "ExportInvrecei",
                    "InvreceiList": "InvreceiList",
                     //的多语言配置==End
                    




```