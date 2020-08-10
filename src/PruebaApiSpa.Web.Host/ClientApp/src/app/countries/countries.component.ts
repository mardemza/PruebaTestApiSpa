import { CreateUpdateCountryDialogComponent } from './create-update-country/create-update-country-dialog.component';
import { CountryDto } from '@shared/service-proxies/service-proxies';
import { CountryServiceProxy, SearchDto, CountryDtoContextDto } from '@shared/service-proxies/service-proxies';
import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  animations: [appModuleAnimation()],
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.scss']
})
export class CountriesComponent extends AppComponentBase implements OnInit {
  filters: SearchDto = new SearchDto();
  contextCountry: CountryDtoContextDto = new CountryDtoContextDto();
  advancedFiltersVisible: boolean = false;
  isTableLoading: boolean = false;
  isActive: boolean = false;
  totalItem: number = 0;

  constructor(private injector: Injector,
    private _countryService: CountryServiceProxy,
    private _modalService: BsModalService) {
    super(injector);
    this.filters.page = 1;
    this.filters.pageSize = 5;
  }

  ngOnInit(): void {
    this.getDataPage(1);
  }

  getDataPage(page: number) {
    if (!this.isTableLoading) {
      this.filters.page = page;
      this.isTableLoading = true;
      this._countryService.getAll(this.filters).subscribe(result => {
        this.contextCountry = result;
        this.isTableLoading = false;
        this.totalItem = this.contextCountry.metaData.totalItemCount;
        console.log(this.contextCountry);
      });
    }
  }

  pageChanged(event) {
    this.getDataPage(event);
  }

  createCountry() {
    this.showCreateEditCountryDialog();
  }

  editCountry(country: CountryDto) {
    this.showCreateEditCountryDialog(country.id);
  }

  deleteCountry(country: CountryDto) {
    abp.message.confirm(
      "Country " + country.shortName + " will be deleted.",
      undefined,
      (result: boolean) => {
        if (result) {
          this._countryService.delete(country.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.getDataPage(1);
          });
        }
      }
    );
  }
  private showCreateEditCountryDialog(id?: number): void {
    let createOrEditUserDialog: BsModalRef;
    if (!id) {
      createOrEditUserDialog = this._modalService.show(
        CreateUpdateCountryDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditUserDialog = this._modalService.show(
        CreateUpdateCountryDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditUserDialog.content.onSave.subscribe(() => {
      this.getDataPage(1);
    });
  }
}
