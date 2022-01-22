
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import {
CreateOrUpdateMesUserInput,
MesUserEditDto,
MesUserServiceProxy,
KeyValuePairOfStringString
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-or-edit-mes-user',
  templateUrl: './create-or-edit-mes-user.component.html',
  styleUrls:[
	'create-or-edit-mes-user.component.less'
    ],
    })

    export class CreateOrEditMesUserComponent
    extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

    entity: MesUserEditDto=new MesUserEditDto();

    /**
    * 构造函数，在此处配置依赖注入
    */
    constructor(
    injector: Injector,
    private _mesUserService: MesUserServiceProxy

    ) {
    super(injector);
    }

    ngOnInit() :void{
    this.init();
    }


    /**
    * 初始化方法
    */
    init(): void {
    this._mesUserService.getForEdit(this.id).subscribe(result => {
    this.entity = result.mesUser;
    

                           
                           
                           });
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
    const input = new CreateOrUpdateMesUserInput();
    input.mesUser = this.entity;

    this.saving = true;

    this._mesUserService.createOrUpdate(input)
     .pipe(finalize(() => (this.saving = false)))
    .subscribe(() => {
    this.notify.success(this.l('SavedSuccessfully'));
    this.success(true);
    });
    }
    }
