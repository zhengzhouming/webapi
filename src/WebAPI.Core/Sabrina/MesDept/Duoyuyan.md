

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
                    
                     "MesDeptDeptName": "DeptName",
                    "MesDeptDeptNameInputDesc": "请输入DeptName",
                     
                    
                     "MesDeptDeptNumber": "DeptNumber",
                    "MesDeptDeptNumberInputDesc": "请输入DeptNumber",
                     
                    
                     "MesDeptMarsk": "Marsk",
                    "MesDeptMarskInputDesc": "请输入Marsk",
                     
					                     
                    "MesDept": "",
                    "ManageMesDept": "管理",
                    "QueryMesDept": "查询",
                    "CreateMesDept": "添加",
                    "EditMesDept": "编辑",
                    "DeleteMesDept": "删除",
                    "BatchDeleteMesDept": "批量删除",
                    "ExportMesDept": "导出",
                    "MesDeptList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的WebAPI.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "MesDeptDeptName": "MesDeptDeptName",
                    "MesDeptDeptNameInputDesc": "Please input your MesDeptDeptName",
                     
                    
                     "MesDeptDeptNumber": "MesDeptDeptNumber",
                    "MesDeptDeptNumberInputDesc": "Please input your MesDeptDeptNumber",
                     
                    
                     "MesDeptMarsk": "MesDeptMarsk",
                    "MesDeptMarskInputDesc": "Please input your MesDeptMarsk",
                     
					                     
                    "MesDept": "MesDept",
                    "ManageMesDept": "ManageMesDept",
                    "QueryMesDept": "QueryMesDept",
                    "CreateMesDept": "CreateMesDept",
                    "EditMesDept": "EditMesDept",
                    "DeleteMesDept": "DeleteMesDept",
                    "BatchDeleteMesDept": "BatchDeleteMesDept",
                    "ExportMesDept": "ExportMesDept",
                    "MesDeptList": "MesDeptList",
                     //的多语言配置==End
                    




```