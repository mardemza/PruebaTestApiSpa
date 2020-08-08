import { Component, Injector, OnInit, EventEmitter, Output } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';
import { CountryServiceProxy, CountryInputDto } from '@shared/service-proxies/service-proxies';


@Component({
  selector: 'app-create-update-country-dialog',
  templateUrl: './create-update-country-dialog.component.html',
  styleUrls: ['./create-update-country-dialog.component.scss']
})
export class CreateUpdateCountryDialogComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  country: CountryInputDto = new CountryInputDto();
  id: number;

  saving: boolean = false;
  title: string;

  constructor(injector: Injector,
    public bsModalRef: BsModalRef,
    private _countryService: CountryServiceProxy) {
    super(injector);
  }

  ngOnInit() {
    console.log(this.id);
    this.title = !this.id ? "Create Country" : "Edit Country";

    if (this.id) {
      this._countryService.get(this.id).subscribe(result => {
        this.country = result;
      })
    }
  }

  save() {
    this.saving = true;
    this._countryService.addOrUpdate(this.country)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
