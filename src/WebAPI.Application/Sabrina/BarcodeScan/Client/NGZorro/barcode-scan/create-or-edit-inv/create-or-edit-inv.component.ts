
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdateinvInput,invEditDto, invServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-inv',
  templateUrl: './create-or-edit-inv.component.html',
  styleUrls:[
	'create-or-edit-inv.component.less'
  ],
})

export class CreateOrEditinvComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: invEditDto=new invEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _invService: invServiceProxy
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
		this._invService.getForEdit(this.id).subscribe(result => {
			this.entity = result.inv;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdateinvInput();
		input.inv = this.entity;

		this.saving = true;

		this._invService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}
