
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import {
CreateOrUpdateMesWorkTagScanReceiptInput,
MesWorkTagScanReceiptEditDto,
MesWorkTagScanReceiptServiceProxy,
KeyValuePairOfStringString
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-or-edit-mes-work-tag-scan-receipt',
  templateUrl: './create-or-edit-mes-work-tag-scan-receipt.component.html',
  styleUrls:[
	'create-or-edit-mes-work-tag-scan-receipt.component.less'
    ],
    })

    export class CreateOrEditMesWorkTagScanReceiptComponent
    extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

    entity: MesWorkTagScanReceiptEditDto=new MesWorkTagScanReceiptEditDto();

    /**
    * 构造函数，在此处配置依赖注入
    */
    constructor(
    injector: Injector,
    private _mesWorkTagScanReceiptService: MesWorkTagScanReceiptServiceProxy

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
    this._mesWorkTagScanReceiptService.getForEdit(this.id).subscribe(result => {
    this.entity = result.mesWorkTagScanReceipt;
    

                           
                           
                           });
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
    const input = new CreateOrUpdateMesWorkTagScanReceiptInput();
    input.mesWorkTagScanReceipt = this.entity;

    this.saving = true;

    this._mesWorkTagScanReceiptService.createOrUpdate(input)
     .pipe(finalize(() => (this.saving = false)))
    .subscribe(() => {
    this.notify.success(this.l('SavedSuccessfully'));
    this.success(true);
    });
    }
    }
