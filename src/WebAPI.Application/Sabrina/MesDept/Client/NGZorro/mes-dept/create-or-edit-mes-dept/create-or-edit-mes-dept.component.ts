
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import {
CreateOrUpdateMesDeptInput,
MesDeptEditDto,
MesDeptServiceProxy,
KeyValuePairOfStringString
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-or-edit-mes-dept',
  templateUrl: './create-or-edit-mes-dept.component.html',
  styleUrls:[
	'create-or-edit-mes-dept.component.less'
    ],
    })

    export class CreateOrEditMesDeptComponent
    extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

    entity: MesDeptEditDto=new MesDeptEditDto();

    /**
    * 构造函数，在此处配置依赖注入
    */
    constructor(
    injector: Injector,
    private _MesDeptService: MesDeptServiceProxy

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
    this._MesDeptService.getForEdit(this.id).subscribe(result => {
    this.entity = result.MesDept;
    

                           
                           
                           });
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
    const input = new CreateOrUpdateMesDeptInput();
    input.MesDept = this.entity;

    this.saving = true;

    this._MesDeptService.createOrUpdate(input)
     .pipe(finalize(() => (this.saving = false)))
    .subscribe(() => {
    this.notify.success(this.l('SavedSuccessfully'));
    this.success(true);
    });
    }
    }
