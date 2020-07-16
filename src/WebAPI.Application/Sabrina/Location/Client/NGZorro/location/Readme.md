

# 前端配置
# service-proxy.module 配置

1. 首先在前端项目的根目录中的打开 `nswag-> refresh.bat` 批处理文件更新 service-proxies.ts 文件内容

2. 再到文件夹路径为`\src\shared\service-proxies\service-proxy.module.ts` 文件中添加以下代码：

```
@NgModule({
	providers: [
			//以下内容复制进去
			ApiServiceProxies.LocationsServiceProxy,
			//
			],
	})

```

# 菜单配置， 添加到菜单位置
到`AppMenus.ts`文件中添加菜单路径


> 复制以下最新代码段内容：

```

{text:'Locations',i18n:'Locations',acl:'Pages.Locations',icon:'anticon anticon-dashboard',link:'/app/admin/locations'},

```


> 如果您使用的是低版本模板`yoyo-ng-module`的话，请复制以下代码段内容：

```

new MenuItem('Locations', 'Pages.Locations', 'anticon anticon-dashboard', '/app/admin/locations')

```

> '/app/admin/locations') 中的 admin 可以自行更改到你的特定模块下,

# 路由配置， 添加到使用位置路由的代码段


添加以下代码到自己的模块路由中:如`src\app\admin\admin-routing.module.ts`


#### 不带权限
```
{  path: 'locations', component:LocationsComponent },
```

#### 带权限验证

```
{  path: 'locations', component:LocationsComponent,data: { permission: 'Pages.Locations' }  },

```

以上二选一
 
 



# 在本组件的 Module 中，添加以下代码到使用的 @NgModule 中的代码
### ================ 在 declarations 项中:

```
LocationsComponent,
CreateOrEditLocationsComponent,

```

### ================ 在 entryComponents 项中:

```
CreateOrEditLocationsComponent,
```