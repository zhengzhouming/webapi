
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import {
CreateOrUpdateCountReceiInput,
CountReceiEditDto,
CountReceiServiceProxy,
KeyValuePairOfStringString
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-or-edit-count-recei',
  templateUrl: './create-or-edit-count-recei.component.html',
  styleUrls:[
	'create-or-edit-count-recei.component.less'
    ],
    })

    export class CreateOrEditCountReceiComponent
    extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

    entity: CountReceiEditDto=new CountReceiEditDto();

    /**
    * 构造函数，在此处配置依赖注入
    */
    constructor(
    injector: Injector,
    private _countReceiService: CountReceiServiceProxy

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
    this._countReceiService.getForEdit(this.id).subscribe(result => {
    this.entity = result.countRecei;
    

                           
                           
                           });
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
    const input = new CreateOrUpdateCountReceiInput();
    input.countRecei = this.entity;

    this.saving = true;

    this._countReceiService.createOrUpdate(input)
    .finally(() => (this.saving = false))
    .pipe(finalize(() => (this.saving = false)))
    .subscribe(() => {
    this.notify.success(this.l('SavedSuccessfully'));
    this.success(true);
    });
    }
    }
