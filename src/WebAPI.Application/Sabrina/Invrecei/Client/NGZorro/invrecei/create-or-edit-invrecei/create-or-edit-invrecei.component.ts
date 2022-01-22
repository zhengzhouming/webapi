
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import {
CreateOrUpdateInvreceiInput,
InvreceiEditDto,
InvreceiServiceProxy,
KeyValuePairOfStringString
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-or-edit-invrecei',
  templateUrl: './create-or-edit-invrecei.component.html',
  styleUrls:[
	'create-or-edit-invrecei.component.less'
    ],
    })

    export class CreateOrEditInvreceiComponent
    extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

    entity: InvreceiEditDto=new InvreceiEditDto();

    /**
    * 构造函数，在此处配置依赖注入
    */
    constructor(
    injector: Injector,
    private _invreceiService: InvreceiServiceProxy

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
    this._invreceiService.getForEdit(this.id).subscribe(result => {
    this.entity = result.invrecei;
    

                           
                           
                           });
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
    const input = new CreateOrUpdateInvreceiInput();
    input.invrecei = this.entity;

    this.saving = true;

    this._invreceiService.createOrUpdate(input)
    .finally(() => (this.saving = false))
    .pipe(finalize(() => (this.saving = false)))
    .subscribe(() => {
    this.notify.success(this.l('SavedSuccessfully'));
    this.success(true);
    });
    }
    }
