
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdateConPprInput,ConPprEditDto, ConPprServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-con-ppr',
  templateUrl: './create-or-edit-con-ppr.component.html',
  styleUrls:[
	'create-or-edit-con-ppr.component.less'
  ],
})

export class CreateOrEditConPprComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: ConPprEditDto=new ConPprEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _conPprService: ConPprServiceProxy
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
		this._conPprService.getForEdit(this.id).subscribe(result => {
			this.entity = result.conPpr;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdateConPprInput();
		input.conPpr = this.entity;

		this.saving = true;

		this._conPprService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}
