

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
                    
                     "MesUseraccount": "account",
                    "MesUseraccountInputDesc": "请输入account",
                     
                    
                     "MesUserpassword": "password",
                    "MesUserpasswordInputDesc": "请输入password",
                     
                    
                     "MesUseruserName": "userName",
                    "MesUseruserNameInputDesc": "请输入userName",
                     
                    
                     "MesUserdeptID": "deptID",
                    "MesUserdeptIDInputDesc": "请输入deptID",
                     
                    
                     "MesUsermarsk": "marsk",
                    "MesUsermarskInputDesc": "请输入marsk",
                     
					                     
                    "MesUser": "",
                    "ManageMesUser": "管理",
                    "QueryMesUser": "查询",
                    "CreateMesUser": "添加",
                    "EditMesUser": "编辑",
                    "DeleteMesUser": "删除",
                    "BatchDeleteMesUser": "批量删除",
                    "ExportMesUser": "导出",
                    "MesUserList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的WebAPI.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "MesUseraccount": "MesUseraccount",
                    "MesUseraccountInputDesc": "Please input your MesUseraccount",
                     
                    
                     "MesUserpassword": "MesUserpassword",
                    "MesUserpasswordInputDesc": "Please input your MesUserpassword",
                     
                    
                     "MesUseruserName": "MesUseruserName",
                    "MesUseruserNameInputDesc": "Please input your MesUseruserName",
                     
                    
                     "MesUserdeptID": "MesUserdeptID",
                    "MesUserdeptIDInputDesc": "Please input your MesUserdeptID",
                     
                    
                     "MesUsermarsk": "MesUsermarsk",
                    "MesUsermarskInputDesc": "Please input your MesUsermarsk",
                     
					                     
                    "MesUser": "MesUser",
                    "ManageMesUser": "ManageMesUser",
                    "QueryMesUser": "QueryMesUser",
                    "CreateMesUser": "CreateMesUser",
                    "EditMesUser": "EditMesUser",
                    "DeleteMesUser": "DeleteMesUser",
                    "BatchDeleteMesUser": "BatchDeleteMesUser",
                    "ExportMesUser": "ExportMesUser",
                    "MesUserList": "MesUserList",
                     //的多语言配置==End
                    




```