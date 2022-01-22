
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import {
CreateOrUpdateMesWorkTagScanInput,
MesWorkTagScanEditDto,
MesWorkTagScanServiceProxy,
KeyValuePairOfStringString
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-or-edit-mes-work-tag-scan',
  templateUrl: './create-or-edit-mes-work-tag-scan.component.html',
  styleUrls:[
	'create-or-edit-mes-work-tag-scan.component.less'
    ],
    })

    export class CreateOrEditMesWorkTagScanComponent
    extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

    entity: MesWorkTagScanEditDto=new MesWorkTagScanEditDto();

    /**
    * 构造函数，在此处配置依赖注入
    */
    constructor(
    injector: Injector,
    private _mesWorkTagScanService: MesWorkTagScanServiceProxy

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
    this._mesWorkTagScanService.getForEdit(this.id).subscribe(result => {
    this.entity = result.mesWorkTagScan;
    

                           
                           
                           });
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
    const input = new CreateOrUpdateMesWorkTagScanInput();
    input.mesWorkTagScan = this.entity;

    this.saving = true;

    this._mesWorkTagScanService.createOrUpdate(input)
     .pipe(finalize(() => (this.saving = false)))
    .subscribe(() => {
    this.notify.success(this.l('SavedSuccessfully'));
    this.success(true);
    });
    }
    }
