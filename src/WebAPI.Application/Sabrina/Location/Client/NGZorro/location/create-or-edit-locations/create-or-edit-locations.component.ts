
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdateLocationsInput,LocationsEditDto, LocationsServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-locations',
  templateUrl: './create-or-edit-locations.component.html',
  styleUrls:[
	'create-or-edit-locations.component.less'
  ],
})

export class CreateOrEditLocationsComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: LocationsEditDto=new LocationsEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _locationsService: LocationsServiceProxy
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
		this._locationsService.getForEdit(this.id).subscribe(result => {
			this.entity = result.locations;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdateLocationsInput();
		input.locations = this.entity;

		this.saving = true;

		this._locationsService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}
